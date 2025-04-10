using CardTraderApi.Client.Models;
using Microsoft.Extensions.Caching.Memory;
using Polly;
using Polly.Retry;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Web;

namespace CardTraderApi.Client.Apis
{
	internal sealed class BaseRestService
	{
		private readonly HttpClient _httpClient;
		private readonly CardTraderApiClientConfig _clientConfig;
		private readonly IMemoryCache _cache;
		private readonly MemoryCacheEntryOptions _cacheOptions;
		private readonly AsyncRetryPolicy<HttpResponseMessage> _retryPolicy;

		private const int MaxRetryAttempt = 5;

		public BaseRestService(HttpClient httpClient, CardTraderApiClientConfig clientConfig, IMemoryCache cache)
		{
			_httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
			_httpClient.BaseAddress ??= clientConfig.CardTraderApiBaseAddress;
			_clientConfig = clientConfig;
			_cache = cache;

			if (clientConfig.EnableCaching)
			{
				_cacheOptions = new MemoryCacheEntryOptions
				{
					AbsoluteExpirationRelativeToNow = _clientConfig.UseSlidingCacheExpiration ? null : _clientConfig.CacheDuration,
					SlidingExpiration = _clientConfig.UseSlidingCacheExpiration ? _clientConfig.CacheDuration : null,
				};
			}

			_retryPolicy = Policy
				.HandleResult<HttpResponseMessage>(r =>
					r.StatusCode == HttpStatusCode.RequestTimeout ||
					r.StatusCode == HttpStatusCode.TooManyRequests ||
					(int)r.StatusCode >= 500)
				.WaitAndRetryAsync(MaxRetryAttempt, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
					onRetry: (exception, timeSpan, context) =>
					{
						Console.WriteLine($"Retrying due to {exception.Result?.StatusCode}. Wait time: {timeSpan.TotalSeconds}s");
					});
		}

		private async Task<T> HandleResponseAsync<T>(HttpResponseMessage response) where T : class
		{
			var jsonStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
			var obj = await JsonSerializer.DeserializeAsync<T>(jsonStream);

			// Handle error response
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

			var cacheKey = _httpClient.BaseAddress.AbsoluteUri + requestUri;

			if (useCache && _cache != null && _cache.TryGetValue(cacheKey, out T cached))
				return cached;

			var response = await _retryPolicy.ExecuteAsync(async () =>
			{
				var requestMessage = new HttpRequestMessage(method, requestUri);

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
					RequestUri = response.RequestMessage.RequestUri,
					RequestMethod = response.RequestMessage.Method
				};
			}

			if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.Accepted)
			{
				var error = await HandleResponseAsync<Error>(response);
				throw new CardTraderApiException(error.Extra.Content)
				{
					ResponseStatusCode = response.StatusCode,
					RequestUri = response.RequestMessage.RequestUri,
					RequestMethod = response.RequestMessage.Method
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
