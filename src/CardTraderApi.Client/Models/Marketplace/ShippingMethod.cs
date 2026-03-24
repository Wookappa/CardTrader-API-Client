using CardTraderApi.Client.Models.Common;
using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Marketplace
{
	public class ShippingMethod
	{
		[JsonPropertyName("id")]
		public int Id { get; set; }

		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("min_estimate_shipping_days")]
		public int? MinEstimateShippingDays { get; set; }

		[JsonPropertyName("max_estimate_shipping_days")]
		public int? MaxEstimateShippingDays { get; set; }

		[JsonPropertyName("parcel")]
		public bool Parcel { get; set; }

		[JsonPropertyName("tracked")]
		public bool Tracked { get; set; }

		[JsonPropertyName("tracking_link")]
		public string TrackingLink { get; set; }

		[JsonPropertyName("free_shipping_threshold_quantity")]
		public int? FreeShippingThresholdQuantity { get; set; }

		[JsonPropertyName("free_shipping_threshold_price")]
		public Price FreeShippingThresholdPrice { get; set; }

		[JsonPropertyName("formatted_free_shipping_threshold_price")]
		public string FormattedFreeShippingThresholdPrice { get; set; }

		[JsonPropertyName("max_cart_subtotal_price")]
		public Price MaxCartSubtotalPrice { get; set; }

		[JsonPropertyName("formatted_max_cart_subtotal_price")]
		public string FormattedMaxCartSubtotalPrice { get; set; }

		[JsonPropertyName("shipping_method_costs")]
		public List<ShippingMethodCost> ShippingMethodCosts { get; set; }
	}
}
