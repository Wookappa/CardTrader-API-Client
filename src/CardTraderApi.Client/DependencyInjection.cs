using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;

namespace CardTraderApi.Client;

public static class DependencyInjection
{
	public static IHttpClientBuilder AddCardTraderApiClient(this IServiceCollection services, string jwtToken) =>
		AddCardTraderApiClient(services, jwtToken, CardTraderApiClientConfig.GetDefault());

	public static IHttpClientBuilder AddCardTraderApiClient(this IServiceCollection services, string jwtToken, Action<CardTraderApiClientConfig> configure)
	{
		var clientConfig = CardTraderApiClientConfig.GetDefault();
		configure(clientConfig);
		return AddCardTraderApiClient(services, jwtToken, clientConfig);
	}

	private static IHttpClientBuilder AddCardTraderApiClient(this IServiceCollection services, string jwtToken, CardTraderApiClientConfig clientConfig)
	{
		services.AddScoped(_ => clientConfig.Clone());

		services.AddSingleton<ITokenProvider, TokenProvider>(_ =>
		{
			var provider = new TokenProvider();
			if (!string.IsNullOrWhiteSpace(jwtToken))
			{
				provider.SetToken(jwtToken);
			}

			return provider;
		});

		var clientBuilder = services.AddHttpClient<CardTraderApiClient>(client =>
		{
			client.BaseAddress = clientConfig.CardTraderApiBaseAddress;
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			client.DefaultRequestHeaders.Add("User-Agent", "CardPriceApiClient/1.0.0");
		});

		return clientBuilder;
	}
}