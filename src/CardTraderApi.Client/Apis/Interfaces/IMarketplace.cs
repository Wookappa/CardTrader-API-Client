using CardTraderApi.Client.Models.Marketplace;

namespace CardTraderApi.Client.Apis.Interfaces;

/// <summary>
/// APIs for cards. Card objects represent individual Magic: The Gathering cards that players could
/// obtain and add to their collection (with a few minor exceptions).
/// </summary>
public interface IMarketplace
{
	/// <summary>
	/// Get products on Marketplace by blueprintId
	/// </summary>
	/// <param name="blueprintId"></param>
	/// <param name="ct"></param>
	/// <returns></returns>
	Task<MarketplaceProductsResponse> GetMarketPlaceProductByBlueprintId(int blueprintId, CancellationToken ct = default);

	/// <summary>
	/// Get products on Marketplace by expansionId
	/// </summary>
	/// <param name="expansionId"></param>
	/// <param name="ct"></param>
	/// <returns></returns>
	Task<MarketplaceProductsResponse> GetMarketPlaceProductByExpansionId(int expansionId, CancellationToken ct = default);

	/// <summary>
	/// Get user cart
	/// </summary>
	/// <param name="ct"></param>
	/// <returns></returns>
	Task<Cart> GetUserCart(CancellationToken ct = default);

	/// <summary>
	/// Add product to cart with request obj
	/// </summary>
	/// <param name="product"></param>
	/// <param name="ct"></param>
	/// <returns></returns>
	Task<Cart> AddProduct(AddToCartRequest product, CancellationToken ct = default);

	/// <summary>
	/// Add product to cart
	/// </summary>
	/// <param name="productId"></param>
	/// <param name="quantity"></param>
	/// <param name="viaCardTraderZero"></param>
	/// <param name="ct"></param>
	/// <returns></returns>
	Task<Cart> AddProduct(int productId, int quantity = 1, bool viaCardTraderZero = false, CancellationToken ct = default);

	/// <summary>
	/// Remove product from cart
	/// </summary>
	/// <param name="productId"></param>
	/// <param name="quantity"></param>
	/// <param name="ct"></param>
	/// <returns></returns>
	Task<Cart> RemoveProduct(int productId, int quantity = 1, CancellationToken ct = default);

	/// <summary>
	/// Get list of expansions
	/// </summary>
	/// <param name="ct"></param>
	/// <returns></returns>
	Task<List<Expansion>> GetListOfExpansions(CancellationToken ct = default);

	/// <summary>
	/// Get list of games
	/// </summary>
	/// <param name="ct"></param>
	/// <returns></returns>
	Task<GameListResponse> GetListOfGames(CancellationToken ct = default);
}
