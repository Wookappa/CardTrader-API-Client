using CardTraderApi.Client.Apis.Interfaces;
using CardTraderApi.Client.Models.Wishlists;

namespace CardTraderApi.Client.Apis;

///<inheritdoc cref="IWishlists"/>
public class Wishlists : IWishlists
{
	private readonly BaseRestService _restService;

	internal Wishlists(BaseRestService restService)
	{
		_restService = restService;
	}

	public async Task<List<Wishlist>> GetWishlists(int? gameId = null, int page = 1, int limit = 20, CancellationToken ct = default)
	{
		var query = new Dictionary<string, object>();

		if (page > 1)
			query["page"] = page;

		if (limit != 20)
			query["limit"] = limit;

		if (gameId.HasValue)
			query["game_id"] = gameId.Value;

		if (query.Count > 0)
			return await _restService.SendGetRequestWithQueryAsync<List<Wishlist>>(Routes.Wishlists, query, ct: ct).ConfigureAwait(false);

		return await _restService.SendGetRequestAsync<List<Wishlist>>(Routes.Wishlists, true, ct).ConfigureAwait(false);
	}

	public async Task<Wishlist> GetWishlist(int id, CancellationToken ct = default)
	{
		return await _restService.SendGetRequestAsync<Wishlist>(Routes.ForWishlist(id), true, ct).ConfigureAwait(false);
	}

	public async Task<Wishlist> Create(WishlistCreateRequest request, CancellationToken ct = default)
	{
		return await _restService.SendPostRequestAsync<Wishlist>(Routes.Wishlists, request, ct).ConfigureAwait(false);
	}

	public async Task Delete(int id, CancellationToken ct = default)
	{
		await _restService.SendDeleteRequestAsync(Routes.ForWishlist(id), ct).ConfigureAwait(false);
	}
}
