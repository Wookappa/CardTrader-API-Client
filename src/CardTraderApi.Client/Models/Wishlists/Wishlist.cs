using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Wishlists
{
	public class Wishlist
	{
		[JsonPropertyName("id")]
		public int Id { get; set; }

		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("game_id")]
		public int GameId { get; set; }

		[JsonPropertyName("public")]
		public bool Public { get; set; }

		[JsonPropertyName("created_at")]
		public DateTime? CreatedAt { get; set; }

		[JsonPropertyName("updated_at")]
		public DateTime? UpdatedAt { get; set; }

		[JsonPropertyName("items")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public List<WishlistItem> Items { get; set; }
	}
}
