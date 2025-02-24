namespace CardTraderApi.Client.Models.Marketplace.Factory;

public class MarketplaceProductsGetByBlueprintId : MarketplaceProductsByBlueprintIdRequest
{
	public MarketplaceProductsGetByBlueprintId(int blueprintId, bool foil = false, string language = null)
	{
		BlueprintId = blueprintId;
		Foil = foil;
		Language = language;
	}

	public MarketplaceProductsGetByBlueprintId SetBlueprintId(int blueprintId)
	{
		BlueprintId = blueprintId;
		return this;
	}

	public MarketplaceProductsGetByBlueprintId SetLanguage(string language)
	{
		Language = language;
		return this;
	}

	public MarketplaceProductsGetByBlueprintId SetFoil(bool foil)
	{
		Foil = foil;
		return this;
	}
}