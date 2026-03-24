using CardTraderApi.Client.Models.Common;
using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Marketplace
{
	public class ShippingMethodCost
	{
		[JsonPropertyName("from_grams")]
		public int FromGrams { get; set; }

		[JsonPropertyName("to_grams")]
		public int ToGrams { get; set; }

		[JsonPropertyName("price")]
		public Price Price { get; set; }

		[JsonPropertyName("formatted_price")]
		public string FormattedPrice { get; set; }
	}
}
