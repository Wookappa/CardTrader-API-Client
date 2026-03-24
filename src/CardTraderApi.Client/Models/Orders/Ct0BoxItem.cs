using CardTraderApi.Client.Models.Common;
using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Orders
{
	public class Ct0BoxItem
	{
		[JsonPropertyName("id")]
		public int Id { get; set; }

		[JsonPropertyName("quantity")]
		public Ct0BoxItemQuantity Quantity { get; set; }

		[JsonPropertyName("seller")]
		public OrderUser Seller { get; set; }

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

		[JsonPropertyName("bundle_size")]
		public int BundleSize { get; set; }

		[JsonPropertyName("description")]
		public string Description { get; set; }

		[JsonPropertyName("graded")]
		public object Graded { get; set; }

		[JsonPropertyName("properties")]
		public Dictionary<string, object> Properties { get; set; }

		[JsonPropertyName("buyer_price")]
		public Price BuyerPrice { get; set; }

		[JsonPropertyName("formatted_price")]
		public string FormattedPrice { get; set; }

		[JsonPropertyName("mkm_id")]
		public int? MkmId { get; set; }

		[JsonPropertyName("tcg_player_id")]
		public int? TcgPlayerId { get; set; }

		[JsonPropertyName("scryfall_id")]
		public string ScryfallId { get; set; }

		[JsonPropertyName("presale")]
		public bool? Presale { get; set; }

		[JsonPropertyName("presale_ended_at")]
		public DateTime? PresaleEndedAt { get; set; }

		[JsonPropertyName("paid_at")]
		public DateTime? PaidAt { get; set; }

		[JsonPropertyName("estimated_arrived_at")]
		public DateTime? EstimatedArrivedAt { get; set; }

		[JsonPropertyName("arrived_at")]
		public DateTime? ArrivedAt { get; set; }

		[JsonPropertyName("cancelled_at")]
		public DateTime? CancelledAt { get; set; }
	}
}
