namespace CardTraderApi.Client.Models.Marketplace.Factory;

public class MarketplaceProductsGetByExpansionId : MarketplaceProductsByExpansionIdRequest
{
	public MarketplaceProductsGetByExpansionId(int expansionId, bool foil = false, string language = null)
	{
		ExpansionId = expansionId;
		Foil = foil;
		Language = language;
	}

	public MarketplaceProductsGetByExpansionId SetExpansionId(int expansionId)
	{
		ExpansionId = expansionId;
		return this;
	}

	public MarketplaceProductsGetByExpansionId SetLanguage(string language)
	{
		Language = language;
		return this;
	}

	public MarketplaceProductsGetByExpansionId SetFoil(bool foil)
	{
		Foil = foil;
		return this;
	}
}