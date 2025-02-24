using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Common
{
	public class User : Seller
	{
		[JsonPropertyName("country_code")]
		public string CountryCode { get; set; }

		[JsonPropertyName("too_many_request_for_cancel_as_seller")]
		public bool TooManyRequestForCancelAsSeller { get; set; }

		[JsonPropertyName("user_type")]
		public string UserType { get; set; }

		[JsonPropertyName("can_sell_sealed_with_ct_zero")]
		public bool CanSellSealedWithCtZero { get; set; }

		[JsonPropertyName("max_sellable_in24h_quantity")]
		public int? MaxSellableIn24HQuantity { get; set; }

		[JsonPropertyName("can_sell_via_hub")]
		public bool CanSellViaHub { get; set; }
	}
}
