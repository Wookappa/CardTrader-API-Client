using CardTraderApi.Client.Apis.Interfaces;
using CardTraderApi.Client.Models.Inventory;
using CardTraderApi.Client.Models.Inventory.Factory;

namespace CardTraderApi.Client.Apis;

///<inheritdoc cref="IInventory"/>
public class Inventory : IInventory
{
	private readonly BaseRestService _restService;

	internal Inventory(BaseRestService restService)
	{
		_restService = restService;
	}

	public Task<IReadOnlyCollection<InventoryProduct>> GetUserProducts(CancellationToken ct = default)
		=> _restService.SendGetRequestAsync<IReadOnlyCollection<InventoryProduct>>(Routes.ProductsExport, true, ct);

	public Task<IReadOnlyCollection<Expansion>> GetUserExpansions(CancellationToken ct = default)
		=> _restService.SendGetRequestAsync<IReadOnlyCollection<Expansion>>(Routes.ExpansionsExport, true, ct);

	public Task<JobResult> GetJobStatus(string uuid, CancellationToken ct = default)
		=> _restService.SendGetRequestAsync<JobResult>(Routes.ForJob(uuid), true, ct);

	public async Task<ProductResponse> Create(ProductCreateRequest product, CancellationToken ct = default)
	{
		return await _restService.SendPostRequestAsync<ProductResponse>(Routes.Products, product, ct).ConfigureAwait(false);
	}

	public async Task<JobResponse> Create(IEnumerable<ProductCreateRequest> products, CancellationToken ct = default)
	{
		var request = InventoryRequestFactory.CreateProducts(products);
		return await _restService.SendPostRequestAsync<JobResponse>(Routes.ProductsBulkCreate, request, ct).ConfigureAwait(false);
	}

	public async Task<ProductResponse> Create(int blueprintId, decimal price, int quantity = 1, bool graded = false, string description = null, CancellationToken ct = default)
	{
		var request = InventoryRequestFactory.CreateProduct(blueprintId, price, quantity, graded, description);
		return await Create(request, ct).ConfigureAwait(false);
	}

	public async Task<ProductResponse> Update(ProductUpdateRequest product, CancellationToken ct = default)
	{
		if (product.Id <= 0)
			throw new ArgumentException("Invalid product ID", nameof(product));

		return await _restService.SendPutRequestAsync<ProductResponse>(Routes.ForProduct(product.Id), product, ct).ConfigureAwait(false);
	}

	public async Task<JobResponse> Update(IEnumerable<ProductUpdateRequest> products, CancellationToken ct = default)
	{
		var request = InventoryRequestFactory.UpdateProducts(products);
		return await _restService.SendPostRequestAsync<JobResponse>(Routes.ProductsBulkUpdate, request, ct).ConfigureAwait(false);
	}

	public async Task<ProductResponse> Update(int id, decimal price, int quantity = 1, bool graded = false, string description = null, CancellationToken ct = default)
	{
		var request = InventoryRequestFactory.UpdateProduct(id, price, quantity, graded, description);
		return await Update(request, ct).ConfigureAwait(false);
	}

	public async Task<ProductResponse> Delete(int id, CancellationToken ct = default)
	{
		return await _restService.SendDeleteRequestAsync<ProductResponse>(Routes.ForProduct(id), ct).ConfigureAwait(false);
	}

	public async Task<JobResponse> Delete(IEnumerable<int> ids, CancellationToken ct = default)
	{
		var request = InventoryRequestFactory.DeleteProducts(ids);
		return await _restService.SendPostRequestAsync<JobResponse>(Routes.ProductsBulkDestroy, request, ct).ConfigureAwait(false);
	}

	public async Task<ProductResponse> IncrementOrDecrement(int id, int deltaQuantity, CancellationToken ct = default)
	{
		var request = InventoryRequestFactory.IncrementOrDecrement(id, deltaQuantity);
		return await _restService.SendPostRequestAsync<ProductResponse>(Routes.ForProductIncrement(id), request, ct).ConfigureAwait(false);
	}

	public async Task<ImageUploadResponse> AddImage(int productId, string remoteImageUrl, CancellationToken ct = default)
	{
		var content = new MultipartFormDataContent
		{
			{ new StringContent(remoteImageUrl), "uploaded_image[remote_image_url]" }
		};

		return await _restService.SendMultipartPostRequestAsync<ImageUploadResponse>(Routes.ForProductUploadImage(productId), content, ct).ConfigureAwait(false);
	}

	public async Task<ImageUploadResponse> AddImage(int productId, Stream imageStream, string fileName, CancellationToken ct = default)
	{
		var content = new MultipartFormDataContent();
		var streamContent = new StreamContent(imageStream);
		content.Add(streamContent, "uploaded_image[image]", fileName);

		return await _restService.SendMultipartPostRequestAsync<ImageUploadResponse>(Routes.ForProductUploadImage(productId), content, ct).ConfigureAwait(false);
	}

	public async Task RemoveImage(int productId, CancellationToken ct = default)
	{
		await _restService.SendDeleteRequestAsync(Routes.ForProductUploadImage(productId), ct).ConfigureAwait(false);
	}

	public async Task<CsvImportResponse> UploadCsv(int gameId, string replaceStockOrAddToStock, string columnNames, Stream csvStream, string csvFileName, string errorMode = null, CancellationToken ct = default)
	{
		var content = new MultipartFormDataContent
		{
			{ new StreamContent(csvStream), "csv", csvFileName },
			{ new StringContent(gameId.ToString()), "game_id" },
			{ new StringContent(replaceStockOrAddToStock), "replace_stock_or_add_to_stock" },
			{ new StringContent(columnNames), "column_names" }
		};

		if (!string.IsNullOrEmpty(errorMode))
			content.Add(new StringContent(errorMode), "error_mode");

		return await _restService.SendMultipartPostRequestAsync<CsvImportResponse>(Routes.ProductImports, content, ct).ConfigureAwait(false);
	}

	public Task<CsvImportStatusResponse> GetCsvImportStatus(int id, CancellationToken ct = default)
		=> _restService.SendGetRequestAsync<CsvImportStatusResponse>(Routes.ForProductImport(id), true, ct);
}
