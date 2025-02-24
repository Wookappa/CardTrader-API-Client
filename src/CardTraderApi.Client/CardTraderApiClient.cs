using CardTraderApi.Client.Apis;
using CardTraderApi.Client.Apis.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace CardTraderApi.Client;

///<inheritdoc cref="ICardTraderApiClient"/>
public class CardTraderApiClient : ICardTraderApiClient
{
	private readonly Lazy<IInventory> _products;

	///<inheritdoc cref="IInventory"/>
	public IInventory Inventory => _products.Value;

	private readonly Lazy<IMarketplace> _marketProducts;

	///<inheritdoc cref="IMarketplace"/>
	public IMarketplace Marketplace => _marketProducts.Value;

	/// <summary>
	/// Instantiate a new CardTrader API client.
	/// </summary>
	/// <param name="httpClient"></param>
	/// <param name="clientConfig"></param>
	/// <param name="cache"></param>
	public CardTraderApiClient(HttpClient httpClient, CardTraderApiClientConfig clientConfig = null, IMemoryCache cache = null)
	{
		if (clientConfig is null)
		{
			clientConfig = CardTraderApiClientConfig.GetDefault();
			clientConfig.EnableCaching = cache is not null;
		}

		var restService = new BaseRestService(httpClient, clientConfig, cache);
		_products = new Lazy<IInventory>(() => new Inventory(restService));
		_marketProducts = new Lazy<IMarketplace>(() => new Marketplace(restService));
	}
}
