using CardTraderApi.Client.Apis.Interfaces;
using CardTraderApi.Client.Models.Orders;

namespace CardTraderApi.Client.Apis;

///<inheritdoc cref="IOrders"/>
public class Orders : IOrders
{
	private readonly BaseRestService _restService;

	internal Orders(BaseRestService restService)
	{
		_restService = restService;
	}

	public async Task<List<Order>> GetOrders(OrdersQueryRequest query = null, CancellationToken ct = default)
	{
		if (query is not null)
			return await _restService.SendGetRequestWithQueryAsync<List<Order>>(Routes.Orders, query, ct: ct).ConfigureAwait(false);

		return await _restService.SendGetRequestAsync<List<Order>>(Routes.Orders, true, ct).ConfigureAwait(false);
	}

	public async Task<Order> GetOrder(int id, CancellationToken ct = default)
	{
		return await _restService.SendGetRequestAsync<Order>(Routes.ForOrder(id), true, ct).ConfigureAwait(false);
	}

	public async Task<Order> SetTrackingCode(int id, string trackingCode, CancellationToken ct = default)
	{
		var request = new TrackingCodeRequest { TrackingCode = trackingCode };
		return await _restService.SendPutRequestAsync<Order>(Routes.ForOrderTrackingCode(id), request, ct).ConfigureAwait(false);
	}

	public async Task<Order> Ship(int id, CancellationToken ct = default)
	{
		return await _restService.SendPutRequestAsync<Order>(Routes.ForOrderShip(id), null, ct).ConfigureAwait(false);
	}

	public async Task<Order> RequestCancellation(int id, bool relistIfCancelled = false, CancellationToken ct = default)
	{
		var request = new CancellationRequest { RelistIfCancelled = relistIfCancelled };
		return await _restService.SendPutRequestAsync<Order>(Routes.ForOrderRequestCancellation(id), request, ct).ConfigureAwait(false);
	}

	public async Task<Order> ConfirmCancellation(int id, CancellationToken ct = default)
	{
		return await _restService.SendPutRequestAsync<Order>(Routes.ForOrderConfirmCancellation(id), null, ct).ConfigureAwait(false);
	}

	public async Task<List<Ct0BoxItem>> GetCt0BoxItems(CancellationToken ct = default)
	{
		return await _restService.SendGetRequestAsync<List<Ct0BoxItem>>(Routes.Ct0BoxItems, true, ct).ConfigureAwait(false);
	}

	public async Task<Ct0BoxItem> GetCt0BoxItem(int id, CancellationToken ct = default)
	{
		return await _restService.SendGetRequestAsync<Ct0BoxItem>(Routes.ForCt0BoxItem(id), true, ct).ConfigureAwait(false);
	}
}
