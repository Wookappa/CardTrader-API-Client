using CardTraderApi.Client.Apis.Interfaces;
using CardTraderApi.Client.Models.Marketplace;
using CardTraderApi.Client.Models.Marketplace.Factory;

namespace CardTraderApi.Client.Apis;

///<inheritdoc cref="IMarketplace"/>
public class Marketplace : IMarketplace
{
	private readonly BaseRestService _restService;
	private const string GetProductsPath = "api/v2/marketplace/products";
	private const string GetCartPath = "api/v2/cart";
	private const string AddProductPath = "api/v2/cart/add";
	private const string RemoveProductPath = "api/v2/cart/remove";

	internal Marketplace(BaseRestService restService)
	{
		_restService = restService;
	}

	public async Task<MarketplaceProductsResponse> GetMarketPlaceProductByBlueprintId(int blueprintId)
	{
		var request = MarketplaceRequestFactory.GetProductsByBlueprintId(blueprintId);
		return await _restService.SendGetRequestWithQueryAsync<MarketplaceProductsResponse>(GetProductsPath, request);
	}

	public async Task<MarketplaceProductsResponse> GetMarketPlaceProductByExpansionId(int expansionId)
	{
		var request = MarketplaceRequestFactory.GetProductsByExpansionId(expansionId);
		return await _restService.SendGetRequestWithQueryAsync<MarketplaceProductsResponse>(GetProductsPath, request);
	}

	public Task<Cart> GetUserCart() => _restService.SendGetRequestAsync<Cart>(GetCartPath, true);

	public async Task<Cart> AddProduct(AddToCartRequest product)
	{
		return await _restService.SendPostRequestAsync<Cart>(AddProductPath, product);
	}

	public async Task<Cart> AddProduct(int productId, int quantity = 1, bool viaCardTraderZero = false)
	{
		var request = MarketplaceRequestFactory.AddProduct(productId, quantity, viaCardTraderZero);
		return await AddProduct(request);
	}

	public async Task<Cart> RemoveProduct(int productId, int quantity = 1)
	{
		var product = new AddToCartRequest
		{
			ProductId = productId,
			Quantity = quantity
		};

		return await _restService.SendPostRequestAsync<Cart>(RemoveProductPath, product);
	}
}
