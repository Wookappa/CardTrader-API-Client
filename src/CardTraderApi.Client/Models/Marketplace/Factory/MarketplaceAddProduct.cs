namespace CardTraderApi.Client.Models.Marketplace.Factory;

public class MarketplaceAddProduct : AddToCartRequest
{
	public MarketplaceAddProduct(int productId, int quantity, bool viaCardTraderZero = false, BaseAddress billAddress = null, BaseAddress shippingAddress = null)
	{
		ProductId = productId;
		Quantity = quantity;
		ViaCardTraderZero = viaCardTraderZero;
		BillingAddress = billAddress;
		ShippingAddress = shippingAddress;
	}

	public MarketplaceAddProduct SetBillingAddress(BaseAddress billAddress)
	{
		BillingAddress = billAddress;
		return this;
	}

	public MarketplaceAddProduct SetShippingAddress(BaseAddress shippingAddress)
	{
		ShippingAddress = shippingAddress;
		return this;
	}

	public MarketplaceAddProduct SetViaCardTraderZero(bool viaCardTraderZero)
	{
		ViaCardTraderZero = viaCardTraderZero;
		return this;
	}
}