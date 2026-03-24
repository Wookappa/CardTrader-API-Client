using CardTraderApi.Client.Models.Common;
using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Orders
{
	public class OrderShippingMethod
	{
		[JsonPropertyName("id")]
		public int Id { get; set; }

		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("tracked")]
		public bool Tracked { get; set; }

		[JsonPropertyName("tracking_code")]
		public string TrackingCode { get; set; }

		[JsonPropertyName("max_estimate_shipping_days")]
		public int? MaxEstimateShippingDays { get; set; }

		[JsonPropertyName("formatted_price")]
		public string FormattedPrice { get; set; }

		[JsonPropertyName("price")]
		public Price Price { get; set; }

		[JsonPropertyName("seller_price")]
		public Price SellerPrice { get; set; }

		[JsonPropertyName("buyer_price")]
		public Price BuyerPrice { get; set; }
	}
}
