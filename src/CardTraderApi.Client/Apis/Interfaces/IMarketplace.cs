using CardTraderApi.Client.Models.Marketplace;
using System.Collections.Generic;

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
	/// <returns></returns>
	Task<MarketplaceProductsResponse> GetMarketPlaceProductByBlueprintId(int blueprintId);

	/// <summary>
	/// Get products on Marketplace by expansionId
	/// </summary>
	/// <param name="expansionId"></param>
	/// <returns></returns>
	Task<MarketplaceProductsResponse> GetMarketPlaceProductByExpansionId(int expansionId);

	/// <summary>
	/// Get user cart
	/// </summary>
	/// <returns></returns>
	public Task<Cart> GetUserCart();

	/// <summary>
	/// Add product to cart with request obj
	/// </summary>
	/// <param name="product"></param>
	/// <returns></returns>
	Task<Cart> AddProduct(AddToCartRequest product);

	/// <summary>
	/// Add product to cart
	/// </summary>
	/// <param name="productId"></param>
	/// <param name="quantity"></param>
	/// <param name="viaCardTraderZero"></param>
	/// <returns></returns>
	Task<Cart> AddProduct(int productId, int quantity = 1, bool viaCardTraderZero = false);

	/// <summary>
	/// Remove product from cart
	/// </summary>
	/// <param name="productId"></param>
	/// <param name="quantity"></param>
	/// <returns></returns>
	Task<Cart> RemoveProduct(int productId, int quantity = 1);

	/// <summary>
	/// Get list of expansions
	/// </summary>
	/// <returns></returns>
	Task<List<Expansion>> GetListOfExpansions();

	/// <summary>
	/// Get list of games
	/// </summary>
	/// <returns></returns>
	Task<GameListResponse> GetListOfGames();
}
