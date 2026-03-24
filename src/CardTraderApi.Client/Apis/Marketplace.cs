using CardTraderApi.Client.Apis.Interfaces;
using CardTraderApi.Client.Models.Marketplace;
using CardTraderApi.Client.Models.Marketplace.Factory;

namespace CardTraderApi.Client.Apis;

///<inheritdoc cref="IMarketplace"/>
public class Marketplace : IMarketplace
{
	private readonly BaseRestService _restService;

	internal Marketplace(BaseRestService restService)
	{
		_restService = restService;
	}

	public async Task<MarketplaceProductsResponse> GetMarketPlaceProductByBlueprintId(int blueprintId, CancellationToken ct = default)
	{
		var request = MarketplaceRequestFactory.GetProductsByBlueprintId(blueprintId);
		return await _restService.SendGetRequestWithQueryAsync<MarketplaceProductsResponse>(Routes.MarketplaceProducts, request, ct: ct).ConfigureAwait(false);
	}

	public async Task<MarketplaceProductsResponse> GetMarketPlaceProductByExpansionId(int expansionId, CancellationToken ct = default)
	{
		var request = MarketplaceRequestFactory.GetProductsByExpansionId(expansionId);
		return await _restService.SendGetRequestWithQueryAsync<MarketplaceProductsResponse>(Routes.MarketplaceProducts, request, ct: ct).ConfigureAwait(false);
	}

	public Task<Cart> GetUserCart(CancellationToken ct = default)
		=> _restService.SendGetRequestAsync<Cart>(Routes.Cart, true, ct);

	public async Task<Cart> AddProduct(AddToCartRequest product, CancellationToken ct = default)
	{
		return await _restService.SendPostRequestAsync<Cart>(Routes.CartAdd, product, ct).ConfigureAwait(false);
	}

	public async Task<Cart> AddProduct(int productId, int quantity = 1, bool viaCardTraderZero = false, CancellationToken ct = default)
	{
		var request = MarketplaceRequestFactory.AddProduct(productId, quantity, viaCardTraderZero);
		return await AddProduct(request, ct).ConfigureAwait(false);
	}

	public async Task<Cart> RemoveProduct(int productId, int quantity = 1, CancellationToken ct = default)
	{
		var product = new AddToCartRequest
		{
			ProductId = productId,
			Quantity = quantity
		};

		return await _restService.SendPostRequestAsync<Cart>(Routes.CartRemove, product, ct).ConfigureAwait(false);
	}

	public async Task<List<Expansion>> GetListOfExpansions(CancellationToken ct = default)
	{
		return await _restService.SendGetRequestAsync<List<Expansion>>(Routes.Expansions, true, ct).ConfigureAwait(false);
	}

	public async Task<GameListResponse> GetListOfGames(CancellationToken ct = default)
	{
		return await _restService.SendGetRequestAsync<GameListResponse>(Routes.Games, true, ct).ConfigureAwait(false);
	}
}
