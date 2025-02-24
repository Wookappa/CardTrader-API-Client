# CardTraderAPI .NET Client Library

The `CardTraderAPI` is a .NET library designed for seamless interactions with the CardTrader API. It simplifies API calls, manages the HTTP client, supports custom request bodies, and integrates Dependency Injection for use in .NET applications.

## Disclaimer

This project is **not** affiliated with [cardtrader.com](https://www.cardtrader.com/) in any way. It is an unofficial library created to help developers integrate with CardTrader APIs.

## Features

- Simplified HTTP client for API calls.
- Support for creating, updating, and deleting products in the inventory.
- Handling of marketplace items and user cart management.
- Easy integration with Dependency Injection.
- Supports serializing custom bodies (e.g., `product_id` and `quantity`).

## Installation

To install the `CardTraderAPI` NuGet package, run the following command in your project:

.NET CLI
```bash
dotnet add package CardTraderAPI.Client
```

Package Manager
```powershell
NuGet\Install-Package CardTraderAPI.Client
```

Alternatively, you can use the NuGet Package Manager in Visual Studio to search for `CardTraderAPI.Client` and install it.

## Usage

### 1. Setup Dependency Injection and JWT Token

In your `Program.cs`, you need to configure Dependency Injection and provide your JWT token.
```csharp
    using CardTraderApi.Client;
    using Microsoft.Extensions.DependencyInjection;

    namespace ConsoleAppTest
    {
        class Program
        {
            private const string JwtToken = "INSERT_HERE_JWTTOKEN";

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

                // Use the API client to interact with the CardTrader API
                await PerformInventoryOperations(cardTraderApiClient);
            }

            static async Task PerformInventoryOperations(CardTraderApiClient cardTraderApiClient)
            {
                // Example: Get all user products
                var products = await cardTraderApiClient.Inventory.GetUserProducts();
                Console.WriteLine($"Found {products.Count} products.");

                // Example: Add a new product
                var createResponse = await cardTraderApiClient.Inventory.Create(16, 5000.00m, 1);
                Console.WriteLine($"Product created with ID: {createResponse.Resource.Id}");

                // Example: Remove a product
                var deleteResponse = await cardTraderApiClient.Inventory.Delete(createResponse.Resource.Id);
                Console.WriteLine($"Product deleted with ID: {createResponse.Resource.Id}");
            }
        }
    }
```

### 2. Interact with Inventory

You can use the following methods to interact with the inventory:

- **Get all user products**:
```csharp
      var products = await cardTraderApiClient.Inventory.GetUserProducts();
```
- **Add a new product**:
```csharp
      var createResponse = await cardTraderApiClient.Inventory.Create(16, 5000.00m, 1);
```
- **Remove a product**:
```csharp
      var deleteResponse = await cardTraderApiClient.Inventory.Delete(productId);
```
### 3. Interact with Marketplace

You can also interact with the marketplace, such as retrieving items or adding/removing products from the user's cart:

- **Get marketplace items by blueprint ID**:
```csharp
      var marketplaceItems = await cardTraderApiClient.Marketplace.GetMarketPlaceProductByBlueprintId(38955);
```
- **Add a product to the user's cart**:
```csharp
      var cartUpdated = await cardTraderApiClient.Marketplace.AddProduct(285708175, 1, true);
```
- **Remove a product from the user's cart**:
```csharp
      var cartRemoveUpdated = await cardTraderApiClient.Marketplace.RemoveProduct(285708175, 1);
```
### 4. Handling Errors

If an error occurs during an API request, you can catch it like this:
```csharp
    try
    {
        var marketplaceItems = await cardTraderApiClient.Marketplace.GetMarketPlaceProductByBlueprintId(38955);
    }
    catch (CardTraderApiException ex)
    {
        Console.WriteLine($"CardTrader API Exception: {ex.Message}");
        Console.WriteLine($"Status Code: {ex.ResponseStatusCode}");
        Console.WriteLine($"Request URI: {ex.RequestUri}");
        Console.WriteLine($"Request Method: {ex.RequestMethod}");
        throw;
    }
```
## Roadmap

Below is an overview of existing features (marked with `[x]`) and planned features (marked with `[ ]`):

**Marketplace**  
- [x] List Marketplace Products  
- [x] Cart Status  
- [x] Add Product to Cart  
- [x] Remove Product from Cart  
- [ ] Purchase  
- [ ] Shipping Methods  

**Wishlists**  
- [ ] Show  
- [ ] Create  
- [ ] Delete  

**Inventory Management**  
- [x] List your Expansions  
- [x] List your Products  

**One Product Operations**  
- [x] Create  
- [x] Update  
- [x] Delete  
- [x] Increment or Decrement  

**Batch Product Operations**  
- [x] Create  
- [x] Update  
- [x] Delete  
- [x] Job  

**CSV Product Operations**  
- [ ] Upload  
- [ ] Status  

**Order Management**  
- [ ] List your Orders  
- [ ] Order Details  
- [ ] Update  
- [ ] Set Tracking Code  
- [ ] Ship  
- [ ] Request Cancellation  
- [ ] Confirm Cancellation  

**CT0 Box Items**  
- [ ] List your CT0 Box Items  
- [ ] CT0 Box Item Details  

**Errors**  
- [x] Exceptions handled via `CardTraderApiException`  

**Webhooks**  
- [ ] Webhook integration  

## Contributing

Feel free to submit issues, fork the repository, and send pull requests.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
