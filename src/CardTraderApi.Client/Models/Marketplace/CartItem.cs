using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Marketplace
{
	public class CartItem
	{
		[JsonPropertyName("quantity")]
		public int Quantity { get; set; }

		[JsonPropertyName("price_cents")]
		public int PriceCents { get; set; }

		[JsonPropertyName("price_currency")]
		public string PriceCurrency { get; set; }

		[JsonPropertyName("product")]
		public CartProduct Product { get; set; }
	}
}
