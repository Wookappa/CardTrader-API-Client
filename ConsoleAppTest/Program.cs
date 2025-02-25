using CardTraderApi.Client;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleAppTest;

class Program
{
	private const string JwtToken =
		"eyJhbGciOiJSUzI1NiJ9.eyJpc3MiOiJjYXJkdHJhZGVyLXByb2R1Y3Rpb24iLCJzdWIiOiJhcHA6MTIzOTUiLCJhdWQiOiJhcHA6MTIzOTUiLCJleHAiOjQ4ODUyNjI3ODMsImp0aSI6ImE0YzU3Mzg3LWZmZjctNGE2Ni1hNDcxLTgxNGExYWQ0OWQ3YiIsImlhdCI6MTcyOTU4OTE4MywibmFtZSI6Ildvb2thcHBhIEFwcCAyMDI0MTAxNTIxNDY1NiJ9.VmiaVrC2kaR8ef_axnSJpF0AZxz0mO4kBHjFE4eTo73xfcB3doHc5pFqfIwi6DL9ySXTMPqOan1M-q1WscfgvJqT_k2XNPFzbb6pzmqJJWkCl9I_cvtXE6ZvrXwU_yGXhDNheSMfllyOK9-SJCfFQJL8lay6QW9RoYp5kSH1xLn-K7BftZ7s37yIpkJ5jKAdPhHCBtHvOCRRyXjUSA0Fgm5T0vjGKjfUpFFhDazQC-wDnJ29oZ__LshplObBtJjQPzTCwkwTeFi_TFi7rw9DwE90te0N9-pBwUOg3Eqxx9wfr7OmeG6fBZFrBK2XSgkvXDrqm2YaBTi3Rey3wzKXtg";

	static async Task Main()
	{
		// Create a new service collection
		var services = new ServiceCollection();

		// Register the CardTrader API client with Dependency Injection and JWT token
		services.AddCardTraderApiClient(JwtToken);

		// Build the service provider
		var serviceProvider = services.BuildServiceProvider();

		// Retrieve the API client from the DI container
		var cardTraderApiClient = serviceProvider.GetRequiredService<CardTraderApiClient>();


		#region Inventory

		// Get all  user products
		var products = await cardTraderApiClient.Inventory.GetUserProducts();

		foreach (var product in products)
		{
			var marketplaceItemsBlueprintId = await cardTraderApiClient.Marketplace.GetMarketPlaceProductByBlueprintId(product.BlueprintId);
		}

		//// Get all user expansions
		//var expansions = await cardTraderApiClient.Inventory.GetUserExpansions();

		////Sell a new product
		//var createResponse = await cardTraderApiClient.Inventory.Create(16, 5000.00m, 1);

		//var createRequest = InventoryRequestFactory.CreateProduct(16, 5000.58m)
		//	.SetCondition("Slightly Played")
		//	.SetMtgLanguage("French")
		//	.SetUserDataField("Room 1, Shelf 82")
		//	.SetGraded(true);

		//var createResponseObj = await cardTraderApiClient.Inventory.Create(createRequest);

		////Remove a product
		//var deleteResponse = await cardTraderApiClient.Inventory.Delete(createResponseObj.Resource.Id);

		////Update a product
		//var updateResponse = await cardTraderApiClient.Inventory.Update(280426466, 1.00m, 1);

		//var updateRequest = InventoryRequestFactory.UpdateProduct(280426466, 1.10m)
		//	.SetCondition("Slightly Played")
		//	.SetMtgLanguage("French")
		//	.SetUserDataField("Room 1, Shelf 82")
		//	.SetGraded(false);

		//var updateRequestObj = await cardTraderApiClient.Inventory.Update(updateRequest);

		//var increaseProductResponse = await cardTraderApiClient.Inventory.IncrementOrDecrement(280426466, 1);
		//var decreaseProductResponse = await cardTraderApiClient.Inventory.IncrementOrDecrement(280426466, -1);

		//var createBulkRequests = new List<ProductInventoryCreate>
		//{
		//	InventoryRequestFactory.CreateProduct(16, 1230.58m)
		//		.SetCondition("Slightly Played")
		//		.SetUserDataField("Room 1, Shelf 82")
		//		.SetGraded(false),

		//	InventoryRequestFactory.CreateProduct(17, 1230.58m)
		//		.SetCondition("Near Mint")
		//		.SetUserDataField("Room 2, Shelf 45")
		//		.SetGraded(false),

		//	InventoryRequestFactory.CreateProduct(18, 1230.58m)
		//		.SetCondition("Lightly Played")
		//		.SetUserDataField("Room 3, Shelf 60")
		//		.SetGraded(false),

		//	InventoryRequestFactory.CreateProduct(19, 1230.58m)
		//		.SetCondition("Moderately Played")
		//		.SetUserDataField("Room 4, Shelf 20")
		//		.SetGraded(false)
		//};

		//var createBulkRequestsObj = await cardTraderApiClient.Inventory.Create(createBulkRequests);

		//var jobResult = await cardTraderApiClient.Inventory.GetJobStatus(createBulkRequestsObj.Job);

		//var productsIdsInserted = jobResult.Results.Select(x => x.ProductId).ToList();

		//var updateBulkRequest = new List<ProductInventoryUpdate>();

		//foreach (var id in productsIdsInserted)
		//{
		//	var updateRequestItem = InventoryRequestFactory.UpdateProduct(id, 2230.00m);

		//	updateBulkRequest.Add((updateRequestItem));
		//}

		//var updateBulkResult = await cardTraderApiClient.Inventory.Update(updateBulkRequest);

		//var deleteBulkResult = await cardTraderApiClient.Inventory.Delete(productsIdsInserted);

		#endregion

		////Get all marketplace items by blueprint id and expansion id
		//try
		//{
		//	var marketplaceItemsBlueprintId = await cardTraderApiClient.Marketplace.GetMarketPlaceProductByBlueprintId(38955);
		//	var marketplaceItemsExpansionId = await cardTraderApiClient.Marketplace.GetMarketPlaceProductByExpansionId(404);
		//}
		//catch (CardTraderApiException ex)
		//{
		//	// Logs detailed API exception message
		//	Console.WriteLine($"CardTrader API Exception: {ex.Message}");
		//	Console.WriteLine($"Status Code: {ex.ResponseStatusCode}");
		//	Console.WriteLine($"Request URI: {ex.RequestUri}");
		//	Console.WriteLine($"Request Method: {ex.RequestMethod}");
		//	throw;
		//}

		////Get user cart
		//var userCart = await cardTraderApiClient.Marketplace.GetUserCart();

		////Add product on Cart
		//var cartUpdated = await cardTraderApiClient.Marketplace.AddProduct(285708175, 1, true);

		//var billingAddress = new BaseAddress
		//{
		//	Name = null,
		//	Street = null,
		//	Zip = null,
		//	City = null,
		//	StateOrProvince = null,
		//	CountryCode = null
		//};

		//var shippingAddress = new BaseAddress
		//{
		//	Name = null,
		//	Street = null,
		//	Zip = null,
		//	City = null,
		//	StateOrProvince = null,
		//	CountryCode = null
		//};

		//var addProductRequest = MarketplaceRequestFactory.AddProduct(285708175, 1)
		//	.SetViaCardTraderZero(true)
		//	.SetShippingAddress(shippingAddress)
		//	.SetBillingAddress(billingAddress);

		//var cartUpdatedObj = await cardTraderApiClient.Marketplace.AddProduct(addProductRequest);

		////Remove Product From Cart
		//var cartRemoveUpdated = await cardTraderApiClient.Marketplace.RemoveProduct(285708175, 1);
	}
}