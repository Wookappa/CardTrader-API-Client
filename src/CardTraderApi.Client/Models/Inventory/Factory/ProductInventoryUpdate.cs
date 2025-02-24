namespace CardTraderApi.Client.Models.Inventory.Factory;

public class ProductInventoryUpdate : ProductUpdateRequest
{
	public ProductInventoryUpdate SetErrorMode(string errorMode)
	{
		ErrorMode = errorMode;
		return this;
	}

	public ProductInventoryUpdate SetUserDataField(string userData)
	{
		UserDataField = userData;
		return this;
	}

	public ProductInventoryUpdate SetCondition(string condition)
	{
		Properties ??= new Properties();
		Properties.Condition = condition;
		return this;
	}

	public ProductInventoryUpdate SetMtgLanguage(string language)
	{
		Properties ??= new Properties();
		Properties.MtgLanguage = language;
		return this;
	}

	public ProductInventoryUpdate SetGraded(bool graded)
	{
		Graded = graded;
		return this;
	}
}
