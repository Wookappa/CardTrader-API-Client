namespace CardTraderApi.Client.Models.Inventory.Factory
{
	public static class InventoryRequestFactory
	{
		public static ProductInventoryCreate CreateProduct(int blueprintId, decimal price, int quantity = 1, bool graded = false, string description = null)
		{
			return new ProductInventoryCreate
			{
				BlueprintId = blueprintId,
				Price = price,
				Quantity = quantity,
				Graded = graded,
				Description = description
			};
		}

		public static ProductInventoryUpdate UpdateProduct(int id, decimal price, int quantity = 1, bool graded = false, string description = null)
		{
			return new ProductInventoryUpdate
			{
				Id = id,
				Price = price,
				Quantity = quantity,
				Graded = graded,
				Description = description
			};
		}

		public static ProductIncrementDecrementRequest IncrementOrDecrement(int id, int deltaQuantity)
		{
			return new ProductIncrementDecrementRequest
			{
				Id = id,
				DeltaQuantity = deltaQuantity
			};
		}

		public static ProductCreateBulkRequest CreateProducts(IEnumerable<ProductCreateRequest> products)
		{
			return new ProductCreateBulkRequest
			{
				Products = products
			};
		}

		public static ProductDeleteBulkRequest DeleteProducts(IEnumerable<int> ids)
		{
			return new ProductDeleteBulkRequest()
			{
				Products = ids.Select(id => new ProductDeleteRequest { Id = id })
			};
		}

		public static ProductUpdateBulkRequest UpdateProducts(IEnumerable<ProductUpdateRequest> products)
		{
			return new ProductUpdateBulkRequest
			{
				Products = products
			};
		}
	}
}
