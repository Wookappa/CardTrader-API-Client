using CardTraderApi.Client.Models.Common;
using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Orders
{
	public class OrderItem
	{
		[JsonPropertyName("id")]
		public int Id { get; set; }

		[JsonPropertyName("product_id")]
		public int ProductId { get; set; }

		[JsonPropertyName("blueprint_id")]
		public int BlueprintId { get; set; }

		[JsonPropertyName("category_id")]
		public int CategoryId { get; set; }

		[JsonPropertyName("game_id")]
		public int GameId { get; set; }

		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("expansion")]
		public string Expansion { get; set; }

		[JsonPropertyName("quantity")]
		public int Quantity { get; set; }

		[JsonPropertyName("bundle_size")]
		public int BundleSize { get; set; }

		[JsonPropertyName("description")]
		public string Description { get; set; }

		[JsonPropertyName("tag")]
		public string Tag { get; set; }

		[JsonPropertyName("graded")]
		public object Graded { get; set; }

		[JsonPropertyName("user_data_field")]
		public string UserDataField { get; set; }

		[JsonPropertyName("properties")]
		public Dictionary<string, object> Properties { get; set; }

		[JsonPropertyName("seller_price")]
		public Price SellerPrice { get; set; }

		[JsonPropertyName("buyer_price")]
		public Price BuyerPrice { get; set; }

		[JsonPropertyName("cancelled_price")]
		public List<Price> CancelledPrice { get; set; }

		[JsonPropertyName("repurchase_price")]
		public List<Price> RepurchasePrice { get; set; }

		[JsonPropertyName("formatted_price")]
		public string FormattedPrice { get; set; }

		[JsonPropertyName("mkm_id")]
		public int? MkmId { get; set; }

		[JsonPropertyName("tcg_player_id")]
		public int? TcgPlayerId { get; set; }

		[JsonPropertyName("scryfall_id")]
		public string ScryfallId { get; set; }

		[JsonPropertyName("deleted_at")]
		public DateTime? DeletedAt { get; set; }

		[JsonPropertyName("created_at")]
		public DateTime? CreatedAt { get; set; }
	}
}
