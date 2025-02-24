using CardTraderApi.Client.Apis.Interfaces;
using CardTraderApi.Client.Models.Inventory;
using CardTraderApi.Client.Models.Inventory.Factory;

namespace CardTraderApi.Client.Apis;

///<inheritdoc cref="IInventory"/>
public class Inventory : IInventory
{
	private readonly BaseRestService _restService;
	private const string GetProductsPath = "api/v2/products/export";
	private const string GetExpansionsPath = "api/v2/expansions/export";
	private const string ProductCreatePath = "api/v2/products";
	private const string ProductBulkCreatePath = "api/v2/products/bulk_create";
	private const string ProductUpdateOrDeletePath = "api/v2/products/";
	private const string ProductBulkUpdatePath = "api/v2/products/bulk_update";
	private const string ProductBulkDeletePath = "api/v2/products/bulk_destroy";
	private const string ProductIncrementOrDecrementPath = "api/v2/products/{0}/increment";

	private const string GetJobStatusPath = "api/v2/jobs/{0}";

	internal Inventory(BaseRestService restService)
	{
		_restService = restService;
	}

	public Task<IReadOnlyCollection<Product>> GetUserProducts() => _restService.SendGetRequestAsync<IReadOnlyCollection<Product>>(GetProductsPath, true);
	public Task<IReadOnlyCollection<Expansion>> GetUserExpansions() => _restService.SendGetRequestAsync<IReadOnlyCollection<Expansion>>(GetExpansionsPath, true);
	public Task<JobResult> GetJobStatus(string uuid) => _restService.SendGetRequestAsync<JobResult>(string.Format(GetJobStatusPath, uuid), true);


	public async Task<ProductResponse> Create(ProductCreateRequest product)
	{
		return await _restService.SendPostRequestAsync<ProductResponse>(ProductCreatePath, product);
	}

	public async Task<JobResponse> Create(IEnumerable<ProductCreateRequest> products)
	{
		var request = InventoryRequestFactory.CreateProducts(products);
		return await _restService.SendPostRequestAsync<JobResponse>(ProductBulkCreatePath, request);
	}

	public async Task<ProductResponse> Create(int blueprintId, decimal price, int quantity = 1, bool graded = false, string description = null)
	{
		var request = InventoryRequestFactory.CreateProduct(blueprintId, price, quantity, graded, description);
		return await Create(request);
	}

	public async Task<ProductResponse> Update(ProductUpdateRequest product)
	{
		if (product.Id <= 0)
			throw new ArgumentException("Invalid product ID", nameof(product));

		var updateUrl = $"{ProductUpdateOrDeletePath}{product.Id}";
		return await _restService.SendPutRequestAsync<ProductResponse>(updateUrl, product);
	}

	public async Task<JobResponse> Update(IEnumerable<ProductUpdateRequest> products)
	{
		var request = InventoryRequestFactory.UpdateProducts(products);
		return await _restService.SendPostRequestAsync<JobResponse>(ProductBulkUpdatePath, request);
	}

	public async Task<ProductResponse> Update(int id, decimal price, int quantity = 1, bool graded = false, string description = null)
	{
		var request = InventoryRequestFactory.UpdateProduct(id, price, quantity, graded, description);
		return await Update(request);
	}

	public async Task<ProductResponse> Delete(int id)
	{
		var deleteUrl = $"{ProductUpdateOrDeletePath}{id}";
		return await _restService.SendDeleteRequestAsync<ProductResponse>(deleteUrl);
	}

	public async Task<JobResponse> Delete(IEnumerable<int> ids)
	{
		var deleteUrl = ProductBulkDeletePath;
		var request = InventoryRequestFactory.DeleteProducts(ids);

		return await _restService.SendPostRequestAsync<JobResponse>(deleteUrl, request);
	}

	public async Task<ProductResponse> IncrementOrDecrement(int id, int deltaQuantity)
	{
		var request = InventoryRequestFactory.IncrementOrDecrement(id, deltaQuantity);
		var updateUrl = string.Format(ProductIncrementOrDecrementPath, id);

		return await _restService.SendPostRequestAsync<ProductResponse>(updateUrl, request);
	}
}
