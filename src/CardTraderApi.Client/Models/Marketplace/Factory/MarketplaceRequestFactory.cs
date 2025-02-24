namespace CardTraderApi.Client.Models.Marketplace.Factory
{
	public static class MarketplaceRequestFactory
	{
		public static MarketplaceProductsGetByBlueprintId GetProductsByBlueprintId(int blueprintId, bool foil = false, string language = null)
		{
			return new MarketplaceProductsGetByBlueprintId(blueprintId, foil, language);
		}

		public static MarketplaceProductsGetByExpansionId GetProductsByExpansionId(int expansionId, bool foil = false, string language = null)
		{
			return new MarketplaceProductsGetByExpansionId(expansionId, foil, language);
		}

		public static MarketplaceAddProduct AddProduct(int productId, int quantity, bool viaCardTraderZero = false)
		{
			return new MarketplaceAddProduct(productId, quantity, viaCardTraderZero);
		}
	}
}
