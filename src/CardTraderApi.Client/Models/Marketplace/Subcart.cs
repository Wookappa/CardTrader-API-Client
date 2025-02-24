using CardTraderApi.Client.Models.Common;
using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Marketplace
{
	public class Subcart
	{
		[JsonPropertyName("id")]
		public int Id { get; set; }

		[JsonPropertyName("seller")]
		public Seller Seller { get; set; }

		[JsonPropertyName("via_cardtrader_zero")]
		public bool ViaCardTraderZero { get; set; }

		[JsonPropertyName("cart_items")]
		public List<CartItem> CartItems { get; set; }
	}
}
