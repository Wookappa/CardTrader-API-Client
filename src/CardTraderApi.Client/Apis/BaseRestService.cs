using CardTraderApi.Client.Models;
using Microsoft.Extensions.Caching.Memory;
using Polly;
using Polly.Retry;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Web;

namespace CardTraderApi.Client.Apis
{
	internal sealed class BaseRestService
	{
		private readonly HttpClient _httpClient;
		private readonly ITokenProvider _tokenProvider;
		private readonly IMemoryCache _cache;
		private readonly MemoryCacheEntryOptions _cacheOptions;
		private readonly AsyncRetryPolicy<HttpResponseMessage> _retryPolicy;

		private const int MaxRetryAttempt = 5;

		public BaseRestService(HttpClient httpClient, CardTraderApiClientConfig clientConfig, IMemoryCache cache, ITokenProvider tokenProvider)
		{
			_httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
			_tokenProvider = tokenProvider ?? throw new ArgumentNullException(nameof(tokenProvider));
			_httpClient.BaseAddress ??= clientConfig.CardTraderApiBaseAddress;
			_cache = cache;

			if (clientConfig.EnableCaching)
			{
				_cacheOptions = new MemoryCacheEntryOptions
				{
					AbsoluteExpirationRelativeToNow = clientConfig.UseSlidingCacheExpiration ? null : clientConfig.CacheDuration,
					SlidingExpiration = clientConfig.UseSlidingCacheExpiration ? clientConfig.CacheDuration : null,
				};
			}

			_retryPolicy = Policy
				.HandleResult<HttpResponseMessage>(r =>
					r.StatusCode == HttpStatusCode.RequestTimeout ||
					r.StatusCode == HttpStatusCode.TooManyRequests ||
					(int)r.StatusCode >= 500)
				.WaitAndRetryAsync(MaxRetryAttempt, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
					onRetry: (exception, timeSpan, _) =>
					{
						Console.WriteLine($"Retrying due to {exception.Result?.StatusCode}. Wait time: {timeSpan.TotalSeconds}s");
					});
		}

		private async Task<T> HandleResponseAsync<T>(HttpResponseMessage response) where T : class
		{
			var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

			if (content.StartsWith("<!DOCTYPE html>", StringComparison.OrdinalIgnoreCase))
			{
				var cardTraderMessage = ExtractCardTraderMessage(content);

				throw new CardTraderApiException($"CardTrader Api Error: {cardTraderMessage}")
				{
					ResponseStatusCode = response.StatusCode,
					RequestUri = response.RequestMessage?.RequestUri,
					RequestMethod = response.RequestMessage?.Method
				};
			}

			var jsonStream = new MemoryStream(Encoding.UTF8.GetBytes(content));
			var obj = await JsonSerializer.DeserializeAsync<T>(jsonStream);

			if (obj is Error)
			{
				jsonStream.Position = 0;
				var errorDetails = await JsonSerializer.DeserializeAsync<Error>(jsonStream);
				if (response.RequestMessage != null)
					throw new CardTraderApiException(errorDetails.Extra.Content)
					{
						ResponseStatusCode = response.StatusCode,
						RequestUri = response.RequestMessage.RequestUri,
						RequestMethod = response.RequestMessage.Method,
						CardTraderError = errorDetails
					};
			}

			return obj;
		}

		private string ExtractCardTraderMessage(string htmlContent)
		{
			try
			{
				const string startTag = "<p>";
				const string endTag = "</p>";

				var startIndex = htmlContent.IndexOf(startTag, StringComparison.OrdinalIgnoreCase);
				var endIndex = htmlContent.IndexOf(endTag, startIndex, StringComparison.OrdinalIgnoreCase);

				if (startIndex != -1 && endIndex != -1)
				{
					startIndex += startTag.Length;
					return htmlContent.Substring(startIndex, endIndex - startIndex).Trim();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error extracting error message: {ex.Message}");
			}

			return "Unknown error message.";
		}

		private async Task<T> SendRequestAsync<T>(string resourceUrl, HttpMethod method, object data = null, bool useCache = true) where T : class
		{
			if (string.IsNullOrWhiteSpace(resourceUrl))
				throw new ArgumentNullException(nameof(resourceUrl));

			var requestUri = resourceUrl;

			if (method == HttpMethod.Get && data != null)
			{
				var queryString = QueryStringHelper.ToQueryString(data);
				requestUri += queryString;
			}

			var cacheKey = _httpClient.BaseAddress?.AbsoluteUri + requestUri;

			if (useCache && _cache != null && _cache.TryGetValue(cacheKey, out T cached))
				return cached;

			var response = await _retryPolicy.ExecuteAsync(async () =>
			{
				var requestMessage = new HttpRequestMessage(method, requestUri);

				var token = _tokenProvider.JwtToken;

				if (!string.IsNullOrWhiteSpace(token))
				{
					requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
				}

				if (data != null && method != HttpMethod.Get)
				{
					var json = JsonSerializer.Serialize(data);
					requestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");
				}

				return await _httpClient.SendAsync(requestMessage);
			});

			if (response.StatusCode == HttpStatusCode.NotFound)
			{
				throw new CardTraderApiException("Resource not found")
				{
					ResponseStatusCode = response.StatusCode,
					RequestUri = response.RequestMessage?.RequestUri,
					RequestMethod = response.RequestMessage?.Method
				};
			}

			if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.Accepted)
			{
				var error = await HandleResponseAsync<Error>(response);
				throw new CardTraderApiException(error.Extra.Content)
				{
					ResponseStatusCode = response.StatusCode,
					RequestUri = response.RequestMessage?.RequestUri,
					RequestMethod = response.RequestMessage?.Method
				};
			}

			var obj = await HandleResponseAsync<T>(response);

			if (useCache) _cache?.Set(cacheKey, obj, _cacheOptions);

			return obj;
		}

		public Task<T> GetAsync<T>(string resourceUrl, bool useCache = true) where T : class
		{
			return SendRequestAsync<T>(resourceUrl, HttpMethod.Get, null, useCache);
		}

		public Task<T> SendGetRequestAsync<T>(string resourceUrl, bool useCache = true) where T : class
		{
			return SendRequestAsync<T>(resourceUrl, HttpMethod.Get, null, useCache);
		}

		public Task<T> SendPostRequestAsync<T>(string resourceUrl, object data) where T : class
		{
			return SendRequestAsync<T>(resourceUrl, HttpMethod.Post, data);
		}

		public Task<T> SendPutRequestAsync<T>(string resourceUrl, object data) where T : class
		{
			return SendRequestAsync<T>(resourceUrl, HttpMethod.Put, data);
		}

		public Task<T> SendDeleteRequestAsync<T>(string resourceUrl) where T : class
		{
			return SendRequestAsync<T>(resourceUrl, HttpMethod.Delete);
		}

		private static string BuildQueryString(object parameters)
		{
			if (parameters == null)
				return string.Empty;

			var json = JsonSerializer.Serialize(parameters);

			var dict = JsonSerializer.Deserialize<Dictionary<string, object>>(json);
			var query = HttpUtility.ParseQueryString(string.Empty);

			foreach (var kvp in dict)
			{
				if (kvp.Value != null)
					query[kvp.Key] = kvp.Value.ToString();
			}

			return query.ToString();
		}

		public async Task<T> SendGetRequestWithQueryAsync<T>(string resourceUrl, object queryParams, bool useCache = true) where T : class
		{
			if (string.IsNullOrWhiteSpace(resourceUrl))
				throw new ArgumentNullException(nameof(resourceUrl));

			var queryString = BuildQueryString(queryParams);
			var fullUrl = string.IsNullOrEmpty(queryString) ? resourceUrl : $"{resourceUrl}?{queryString}";

			return await SendRequestAsync<T>(fullUrl, HttpMethod.Get, null, useCache);
		}
	}
}
