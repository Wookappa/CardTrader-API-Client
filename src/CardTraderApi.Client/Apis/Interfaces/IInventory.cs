using CardTraderApi.Client.Models.Inventory;

namespace CardTraderApi.Client.Apis.Interfaces;

/// <summary>
/// APIs for cards. Card objects represent individual Magic: The Gathering cards that players could
/// obtain and add to their collection (with a few minor exceptions).
/// </summary>
public interface IInventory
{
	/// <summary>
	/// Get the user's products
	/// </summary>
	/// <param name="ct"></param>
	/// <returns></returns>
	Task<IReadOnlyCollection<InventoryProduct>> GetUserProducts(CancellationToken ct = default);

	/// <summary>
	/// Get the user's expansions
	/// </summary>
	/// <param name="ct"></param>
	/// <returns></returns>
	Task<IReadOnlyCollection<Expansion>> GetUserExpansions(CancellationToken ct = default);

	/// <summary>
	/// Create a new product
	/// </summary>
	/// <param name="product"></param>
	/// <param name="ct"></param>
	/// <returns></returns>
	Task<ProductResponse> Create(ProductCreateRequest product, CancellationToken ct = default);

	/// <summary>
	/// Create a new product overload
	/// </summary>
	/// <param name="blueprintId"></param>
	/// <param name="price"></param>
	/// <param name="quantity"></param>
	/// <param name="graded"></param>
	/// <param name="description"></param>
	/// <param name="ct"></param>
	/// <returns></returns>
	Task<ProductResponse> Create(int blueprintId, decimal price, int quantity = 1, bool graded = false, string description = null, CancellationToken ct = default);

	/// <summary>
	/// Bulk create products
	/// </summary>
	/// <param name="products"></param>
	/// <param name="ct"></param>
	/// <returns></returns>
	Task<JobResponse> Create(IEnumerable<ProductCreateRequest> products, CancellationToken ct = default);

	/// <summary>
	/// Create a new product
	/// </summary>
	/// <param name="product"></param>
	/// <param name="ct"></param>
	/// <returns></returns>
	Task<ProductResponse> Update(ProductUpdateRequest product, CancellationToken ct = default);

	/// <summary>
	/// Update a product overload
	/// </summary>
	/// <param name="id"></param>
	/// <param name="price"></param>
	/// <param name="quantity"></param>
	/// <param name="graded"></param>
	/// <param name="description"></param>
	/// <param name="ct"></param>
	/// <returns></returns>
	Task<ProductResponse> Update(int id, decimal price, int quantity = 1, bool graded = false,
		string description = null, CancellationToken ct = default);

	/// <summary>
	/// Bulk update products
	/// </summary>
	/// <param name="products"></param>
	/// <param name="ct"></param>
	/// <returns></returns>
	Task<JobResponse> Update(IEnumerable<ProductUpdateRequest> products, CancellationToken ct = default);

	/// <summary>
	/// delete a product by id
	/// </summary>
	/// <param name="id"></param>
	/// <param name="ct"></param>
	/// <returns></returns>
	Task<ProductResponse> Delete(int id, CancellationToken ct = default);

	/// <summary>
	/// Bulk delete products
	/// </summary>
	/// <param name="ids"></param>
	/// <param name="ct"></param>
	/// <returns></returns>
	Task<JobResponse> Delete(IEnumerable<int> ids, CancellationToken ct = default);

	/// <summary>
	/// Increment or decrement the quantity of a product
	/// </summary>
	/// <param name="id"></param>
	/// <param name="deltaQuantity"></param>
	/// <param name="ct"></param>
	/// <returns></returns>
	Task<ProductResponse> IncrementOrDecrement(int id, int deltaQuantity, CancellationToken ct = default);

	/// <summary>
	/// Get the status of a job
	/// </summary>
	/// <param name="uuid"></param>
	/// <param name="ct"></param>
	/// <returns></returns>
	Task<JobResult> GetJobStatus(string uuid, CancellationToken ct = default);
}
