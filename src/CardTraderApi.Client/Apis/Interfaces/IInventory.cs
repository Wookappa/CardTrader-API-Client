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
	/// <returns></returns>
	Task<IReadOnlyCollection<Product>> GetUserProducts();

	/// <summary>
	/// Get the user's expansions
	/// </summary>
	/// <returns></returns>
	Task<IReadOnlyCollection<Expansion>> GetUserExpansions();

	/// <summary>
	/// Create a new product
	/// </summary>
	/// <param name="product"></param>
	/// <returns></returns>
	Task<ProductResponse> Create(ProductCreateRequest product);

	/// <summary>
	/// Create a new product overload
	/// </summary>
	/// <param name="blueprintId"></param>
	/// <param name="price"></param>
	/// <param name="quantity"></param>
	/// <param name="graded"></param>
	/// <param name="description"></param>
	/// <returns></returns>
	Task<ProductResponse> Create(int blueprintId, decimal price, int quantity = 1, bool graded = false, string description = null);

	/// <summary>
	/// Bulk create products
	/// </summary>
	/// <param name="products"></param>
	/// <returns></returns>
	Task<JobResponse> Create(IEnumerable<ProductCreateRequest> products);

	/// <summary>
	/// Create a new product
	/// </summary>
	/// <param name="product"></param>
	/// <returns></returns>
	Task<ProductResponse> Update(ProductUpdateRequest product);

	/// <summary>
	/// Update a product overload
	/// </summary>
	/// <param name="id"></param>
	/// <param name="price"></param>
	/// <param name="quantity"></param>
	/// <param name="graded"></param>
	/// <param name="description"></param>
	/// <returns></returns>
	Task<ProductResponse> Update(int id, decimal price, int quantity = 1, bool graded = false,
		string description = null);

	/// <summary>
	/// Bulk update products
	/// </summary>
	/// <param name="products"></param>
	/// <returns></returns>
	Task<JobResponse> Update(IEnumerable<ProductUpdateRequest> products);

	/// <summary>
	/// delete a product by id
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	Task<ProductResponse> Delete(int id);

	/// <summary>
	/// Bulk delete products
	/// </summary>
	/// <param name="ids"></param>
	/// <returns></returns>
	Task<JobResponse> Delete(IEnumerable<int> ids);

	/// <summary>
	/// Increment or decrement the quantity of a product
	/// </summary>
	/// <param name="id"></param>
	/// <param name="deltaQuantity"></param>
	/// <returns></returns>
	Task<ProductResponse> IncrementOrDecrement(int id, int deltaQuantity);

	/// <summary>
	/// Get the status of a job
	/// </summary>
	/// <param name="uuid"></param>
	/// <returns></returns>
	Task<JobResult> GetJobStatus(string uuid);
}
