using CardTraderApi.Client.Models;
using Microsoft.Extensions.Caching.Memory;
using Polly;
using Polly.Retry;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Web;

namespace CardTraderApi.Client.Apis;

internal sealed class BaseRestService
{
	private readonly HttpClient _httpClient;
	private readonly ITokenProvider _tokenProvider;
	private readonly IMemoryCache _cache;
	private readonly MemoryCacheEntryOptions _cacheOptions;
	private readonly ResiliencePipeline<HttpResponseMessage> _retryPipeline;

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

		_retryPipeline = new ResiliencePipelineBuilder<HttpResponseMessage>()
			.AddRetry(new RetryStrategyOptions<HttpResponseMessage>
			{
				ShouldHandle = new PredicateBuilder<HttpResponseMessage>()
					.HandleResult(static r =>
						r.StatusCode is HttpStatusCode.RequestTimeout or HttpStatusCode.TooManyRequests
						|| (int)r.StatusCode >= 500),
				MaxRetryAttempts = clientConfig.MaxRetryAttempts,
				Delay = clientConfig.InitialRetryDelay,
				BackoffType = DelayBackoffType.Exponential,
				UseJitter = true,
			})
			.Build();
	}

	private async Task<T> DeserializeResponseAsync<T>(HttpResponseMessage response, CancellationToken ct) where T : class
	{
		var content = await response.Content.ReadAsStringAsync(ct).ConfigureAwait(false);

		if (content.StartsWith("<!DOCTYPE html>", StringComparison.OrdinalIgnoreCase))
		{
			throw new CardTraderApiException($"CardTrader Api Error: {ExtractCardTraderMessage(content)}")
			{
				ResponseStatusCode = response.StatusCode,
				RequestUri = response.RequestMessage?.RequestUri,
				RequestMethod = response.RequestMessage?.Method
			};
		}

		return JsonSerializer.Deserialize<T>(content);
	}

	private static string ExtractCardTraderMessage(string htmlContent)
	{
		const string startTag = "<p>";
		const string endTag = "</p>";

		var startIndex = htmlContent.IndexOf(startTag, StringComparison.OrdinalIgnoreCase);
		if (startIndex < 0)
			return "Unknown error message.";

		var endIndex = htmlContent.IndexOf(endTag, startIndex, StringComparison.OrdinalIgnoreCase);
		if (endIndex < 0)
			return "Unknown error message.";

		startIndex += startTag.Length;
		return htmlContent[startIndex..endIndex].Trim();
	}

	private async Task<T> SendRequestAsync<T>(string resourceUrl, HttpMethod method, object data = null, bool useCache = true, CancellationToken ct = default) where T : class
	{
		if (string.IsNullOrWhiteSpace(resourceUrl))
			throw new ArgumentNullException(nameof(resourceUrl));

		var cacheKey = $"{_httpClient.BaseAddress?.AbsoluteUri}{resourceUrl}";

		if (useCache && _cache is not null && _cache.TryGetValue(cacheKey, out T cached))
			return cached;

		var response = await _retryPipeline.ExecuteAsync(async token =>
		{
			var requestMessage = new HttpRequestMessage(method, resourceUrl);

			var jwtToken = _tokenProvider.JwtToken;
			if (!string.IsNullOrWhiteSpace(jwtToken))
				requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

			if (data is not null && method != HttpMethod.Get)
				requestMessage.Content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");

			return await _httpClient.SendAsync(requestMessage, token).ConfigureAwait(false);
		}, ct).ConfigureAwait(false);

		if (response.StatusCode == HttpStatusCode.NotFound)
		{
			throw new CardTraderApiException("Resource not found")
			{
				ResponseStatusCode = response.StatusCode,
				RequestUri = response.RequestMessage?.RequestUri,
				RequestMethod = response.RequestMessage?.Method
			};
		}

		if (response.StatusCode is not HttpStatusCode.OK and not HttpStatusCode.Accepted)
		{
			Error error = null;
			try
			{
				error = await DeserializeResponseAsync<Error>(response, ct).ConfigureAwait(false);
			}
			catch (CardTraderApiException) { throw; }
			catch { /* deserialization may fail for non-JSON error bodies */ }

			throw new CardTraderApiException(error?.Extra?.Content ?? $"Request failed with status {(int)response.StatusCode}")
			{
				ResponseStatusCode = response.StatusCode,
				RequestUri = response.RequestMessage?.RequestUri,
				RequestMethod = response.RequestMessage?.Method,
				CardTraderError = error
			};
		}

		var obj = await DeserializeResponseAsync<T>(response, ct).ConfigureAwait(false);

		if (useCache && _cacheOptions is not null)
			_cache?.Set(cacheKey, obj, _cacheOptions);

		return obj;
	}

	public Task<T> SendGetRequestAsync<T>(string resourceUrl, bool useCache = true, CancellationToken ct = default) where T : class
		=> SendRequestAsync<T>(resourceUrl, HttpMethod.Get, null, useCache, ct);

	public Task<T> SendPostRequestAsync<T>(string resourceUrl, object data, CancellationToken ct = default) where T : class
		=> SendRequestAsync<T>(resourceUrl, HttpMethod.Post, data, false, ct);

	public Task<T> SendPutRequestAsync<T>(string resourceUrl, object data, CancellationToken ct = default) where T : class
		=> SendRequestAsync<T>(resourceUrl, HttpMethod.Put, data, false, ct);

	public Task<T> SendDeleteRequestAsync<T>(string resourceUrl, CancellationToken ct = default) where T : class
		=> SendRequestAsync<T>(resourceUrl, HttpMethod.Delete, null, false, ct);

	public Task<T> SendGetRequestWithQueryAsync<T>(string resourceUrl, object queryParams, bool useCache = true, CancellationToken ct = default) where T : class
	{
		if (string.IsNullOrWhiteSpace(resourceUrl))
			throw new ArgumentNullException(nameof(resourceUrl));

		var queryString = BuildQueryString(queryParams);
		var fullUrl = string.IsNullOrEmpty(queryString) ? resourceUrl : $"{resourceUrl}?{queryString}";

		return SendRequestAsync<T>(fullUrl, HttpMethod.Get, null, useCache, ct);
	}

	private static string BuildQueryString(object parameters)
	{
		if (parameters is null)
			return string.Empty;

		var json = JsonSerializer.Serialize(parameters);
		var dict = JsonSerializer.Deserialize<Dictionary<string, object>>(json);
		var query = HttpUtility.ParseQueryString(string.Empty);

		foreach (var kvp in dict!)
		{
			if (kvp.Value is not null)
				query[kvp.Key] = kvp.Value.ToString();
		}

		return query.ToString() ?? string.Empty;
	}
}
