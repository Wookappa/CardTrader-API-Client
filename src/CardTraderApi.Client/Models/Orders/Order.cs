using CardTraderApi.Client.Models.Common;
using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Orders
{
	public class Order
	{
		[JsonPropertyName("id")]
		public int Id { get; set; }

		[JsonPropertyName("code")]
		public string Code { get; set; }

		[JsonPropertyName("transaction_code")]
		public string TransactionCode { get; set; }

		[JsonPropertyName("via_cardtrader_zero")]
		public bool ViaCardTraderZero { get; set; }

		[JsonPropertyName("order_as")]
		public string OrderAs { get; set; }

		[JsonPropertyName("state")]
		public string State { get; set; }

		[JsonPropertyName("size")]
		public int Size { get; set; }

		[JsonPropertyName("paid_at")]
		public DateTime? PaidAt { get; set; }

		[JsonPropertyName("credit_added_to_seller_at")]
		public DateTime? CreditAddedToSellerAt { get; set; }

		[JsonPropertyName("sent_at")]
		public DateTime? SentAt { get; set; }

		[JsonPropertyName("cancelled_at")]
		public DateTime? CancelledAt { get; set; }

		[JsonPropertyName("presale_ended_at")]
		public DateTime? PresaleEndedAt { get; set; }

		[JsonPropertyName("fee_percentage")]
		public string FeePercentage { get; set; }

		[JsonPropertyName("packing_number")]
		public int PackingNumber { get; set; }

		[JsonPropertyName("presale")]
		public bool? Presale { get; set; }

		[JsonPropertyName("seller")]
		public OrderUser Seller { get; set; }

		[JsonPropertyName("buyer")]
		public OrderUser Buyer { get; set; }

		[JsonPropertyName("cancel_requester")]
		public OrderUser CancelRequester { get; set; }

		[JsonPropertyName("seller_total")]
		public Price SellerTotal { get; set; }

		[JsonPropertyName("buyer_total")]
		public Price BuyerTotal { get; set; }

		[JsonPropertyName("fee_amount")]
		public Price FeeAmount { get; set; }

		[JsonPropertyName("seller_fee_amount")]
		public Price SellerFeeAmount { get; set; }

		[JsonPropertyName("subtotal")]
		public Price Subtotal { get; set; }

		[JsonPropertyName("seller_subtotal")]
		public Price SellerSubtotal { get; set; }

		[JsonPropertyName("buyer_subtotal")]
		public Price BuyerSubtotal { get; set; }

		[JsonPropertyName("formatted_subtotal")]
		public string FormattedSubtotal { get; set; }

		[JsonPropertyName("formatted_total")]
		public string FormattedTotal { get; set; }

		[JsonPropertyName("order_shipping_address")]
		public OrderAddress OrderShippingAddress { get; set; }

		[JsonPropertyName("order_billing_address")]
		public OrderAddress OrderBillingAddress { get; set; }

		[JsonPropertyName("order_shipping_method")]
		public OrderShippingMethod OrderShippingMethod { get; set; }

		[JsonPropertyName("order_items")]
		public List<OrderItem> OrderItems { get; set; }
	}
}
