using CardTraderApi.Client.Models.Wishlists;

namespace CardTraderApi.Client.Apis.Interfaces;

/// <summary>
/// APIs for managing wishlists.
/// </summary>
public interface IWishlists
{
	/// <summary>
	/// Get a paginated list of wishlists for the current user.
	/// </summary>
	/// <param name="gameId">Optional game ID filter.</param>
	/// <param name="page">Page number (starting from 1).</param>
	/// <param name="limit">Number of results per page (1-20).</param>
	/// <param name="ct"></param>
	/// <returns></returns>
	Task<List<Wishlist>> GetWishlists(int? gameId = null, int page = 1, int limit = 20, CancellationToken ct = default);

	/// <summary>
	/// Get the details of a specific wishlist by its ID.
	/// </summary>
	/// <param name="id">The wishlist ID.</param>
	/// <param name="ct"></param>
	/// <returns></returns>
	Task<Wishlist> GetWishlist(int id, CancellationToken ct = default);

	/// <summary>
	/// Create a new wishlist.
	/// </summary>
	/// <param name="request">The wishlist create request.</param>
	/// <param name="ct"></param>
	/// <returns></returns>
	Task<Wishlist> Create(WishlistCreateRequest request, CancellationToken ct = default);

	/// <summary>
	/// Delete a wishlist by its ID.
	/// </summary>
	/// <param name="id">The wishlist ID.</param>
	/// <param name="ct"></param>
	/// <returns></returns>
	Task Delete(int id, CancellationToken ct = default);
}
