using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Marketplace
{
	public class AddToCartRequest
	{
		[JsonPropertyName("product_id")]
		public int ProductId { get; set; }

		[JsonPropertyName("quantity")]
		public int Quantity { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[JsonPropertyName("via_cardtrader_zero")]
		public bool ViaCardTraderZero { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[JsonPropertyName("billing_address")]
		public BaseAddress BillingAddress { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[JsonPropertyName("shipping_address")]
		public BaseAddress ShippingAddress { get; set; }
	}
}
