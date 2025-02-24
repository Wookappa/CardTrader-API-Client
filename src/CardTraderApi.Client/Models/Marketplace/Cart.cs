using CardTraderApi.Client.Models.Common;
using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Marketplace
{
	public class Cart
	{
		[JsonPropertyName("id")]
		public int Id { get; set; }

		[JsonPropertyName("total")]
		public Price Total { get; set; }

		[JsonPropertyName("subtotal")]
		public Price Subtotal { get; set; }

		[JsonPropertyName("safeguard_fee_amount")]
		public Price SafeguardFeeAmount { get; set; }

		[JsonPropertyName("ct_zero_fee_amount")]
		public Price CtZeroFeeAmount { get; set; }

		[JsonPropertyName("payment_method_fee_fixed_amount")]
		public Price PaymentMethodFeeFixedAmount { get; set; }

		[JsonPropertyName("payment_method_fee_percentage_amount")]
		public Price PaymentMethodFeePercentageAmount { get; set; }

		[JsonPropertyName("shipping_cost")]
		public Price ShippingCost { get; set; }

		[JsonPropertyName("subcarts")]
		public List<Subcart> Subcarts { get; set; }

		[JsonPropertyName("billing_address")]
		public Address BillingAddress { get; set; }

		[JsonPropertyName("shipping_address")]
		public Address ShippingAddress { get; set; }
	}
}
