using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Wishlists
{
	public class WishlistCreateRequest
	{
		[JsonPropertyName("deck")]
		public WishlistDeck Deck { get; set; }
	}

	public class WishlistDeck
	{
		[JsonPropertyName("game_id")]
		public int GameId { get; set; }

		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("public")]
		public bool Public { get; set; }

		[JsonPropertyName("deck_items_from_text_deck")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string DeckItemsFromTextDeck { get; set; }

		[JsonPropertyName("deck_items_attributes")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public List<WishlistItem> DeckItemsAttributes { get; set; }
	}
}
