namespace CardTraderApi.Client.Models.Inventory.Factory;

public class ProductInventoryCreate : ProductCreateRequest
{
	public ProductInventoryCreate SetErrorMode(string errorMode)
	{
		ErrorMode = errorMode;
		return this;
	}

	public ProductInventoryCreate SetUserDataField(string userData)
	{
		UserDataField = userData;
		return this;
	}

	public ProductInventoryCreate SetCondition(string condition)
	{
		Properties ??= new Properties();
		Properties.Condition = condition;
		return this;
	}

	public ProductInventoryCreate SetMtgLanguage(string language)
	{
		Properties ??= new Properties();
		Properties.MtgLanguage = language;
		return this;
	}

	public ProductInventoryCreate SetGraded(bool graded)
	{
		Graded = graded;
		return this;
	}
}
