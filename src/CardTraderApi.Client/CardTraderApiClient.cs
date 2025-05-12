using CardTraderApi.Client.Apis;
using CardTraderApi.Client.Apis.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace CardTraderApi.Client;

///<inheritdoc cref="ICardTraderApiClient"/>
public class CardTraderApiClient : ICardTraderApiClient
{
	private readonly Lazy<IInventory> _products;
	private readonly Lazy<IMarketplace> _marketProducts;
	private readonly ITokenProvider _tokenProvider;

	///<inheritdoc cref="IInventory"/>
	public IInventory Inventory => _products.Value;

	///<inheritdoc cref="IMarketplace"/>
	public IMarketplace Marketplace => _marketProducts.Value;

	/// <summary>
	/// Instantiate a new CardTrader API client.
	/// </summary>
	/// <param name="httpClient"></param>
	/// <param name="clientConfig"></param>
	/// <param name="cache"></param>
	/// <param name="tokenProvider"></param>
	public CardTraderApiClient(
		HttpClient httpClient,
		CardTraderApiClientConfig clientConfig,
		ITokenProvider tokenProvider,
		IMemoryCache cache = null)
	{
		_tokenProvider = tokenProvider ?? throw new ArgumentNullException(nameof(tokenProvider));
		if (clientConfig is null)
		{
			clientConfig = CardTraderApiClientConfig.GetDefault();
			clientConfig.EnableCaching = cache is not null;
		}

		var restService = new BaseRestService(httpClient, clientConfig, cache, tokenProvider);
		_products = new Lazy<IInventory>(() => new Inventory(restService));
		_marketProducts = new Lazy<IMarketplace>(() => new Marketplace(restService));
	}

	/// <summary>
	/// Updates the JWT token used for authentication in the HTTP client.
	/// This method sets the new token in the internal <see cref="TokenProvider"/> instance,
	/// ensuring that all subsequent HTTP requests use the updated token for authorization.
	/// </summary>
	/// <param name="newJwtToken">The new JWT token to be used for authentication.</param>
	public void UpdateJtwToken(string newJwtToken)
	{
		if (string.IsNullOrWhiteSpace(newJwtToken))
			throw new ArgumentNullException(nameof(newJwtToken));
		_tokenProvider.SetToken(newJwtToken);
	}
}