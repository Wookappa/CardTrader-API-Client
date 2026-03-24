using CardTraderApi.Client.Models.Orders;

namespace CardTraderApi.Client.Apis.Interfaces;

/// <summary>
/// APIs for managing orders, CT0 box items, and order lifecycle operations.
/// </summary>
public interface IOrders
{
	/// <summary>
	/// Get a paginated list of orders.
	/// </summary>
	/// <param name="query">Optional query parameters for filtering and sorting.</param>
	/// <param name="ct"></param>
	/// <returns></returns>
	Task<List<Order>> GetOrders(OrdersQueryRequest query = null, CancellationToken ct = default);

	/// <summary>
	/// Get the details of a specific order.
	/// </summary>
	/// <param name="id">The order ID.</param>
	/// <param name="ct"></param>
	/// <returns></returns>
	Task<Order> GetOrder(int id, CancellationToken ct = default);

	/// <summary>
	/// Set a tracking code for the order.
	/// </summary>
	/// <param name="id">The order ID.</param>
	/// <param name="trackingCode">The tracking code.</param>
	/// <param name="ct"></param>
	/// <returns></returns>
	Task<Order> SetTrackingCode(int id, string trackingCode, CancellationToken ct = default);

	/// <summary>
	/// Mark the order as shipped.
	/// </summary>
	/// <param name="id">The order ID.</param>
	/// <param name="ct"></param>
	/// <returns></returns>
	Task<Order> Ship(int id, CancellationToken ct = default);

	/// <summary>
	/// Request cancellation of an order.
	/// </summary>
	/// <param name="id">The order ID.</param>
	/// <param name="relistIfCancelled">Whether to relist products if the cancellation is confirmed.</param>
	/// <param name="ct"></param>
	/// <returns></returns>
	Task<Order> RequestCancellation(int id, bool relistIfCancelled = false, CancellationToken ct = default);

	/// <summary>
	/// Confirm cancellation of an order.
	/// </summary>
	/// <param name="id">The order ID.</param>
	/// <param name="ct"></param>
	/// <returns></returns>
	Task<Order> ConfirmCancellation(int id, CancellationToken ct = default);

	/// <summary>
	/// Get the list of CT0 box items.
	/// </summary>
	/// <param name="ct"></param>
	/// <returns></returns>
	Task<List<Ct0BoxItem>> GetCt0BoxItems(CancellationToken ct = default);

	/// <summary>
	/// Get the details of a specific CT0 box item.
	/// </summary>
	/// <param name="id">The CT0 box item ID.</param>
	/// <param name="ct"></param>
	/// <returns></returns>
	Task<Ct0BoxItem> GetCt0BoxItem(int id, CancellationToken ct = default);
}
