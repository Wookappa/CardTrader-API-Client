using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Wishlists
{
	public class WishlistItem
	{
		[JsonPropertyName("blueprint_id")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public int? BlueprintId { get; set; }

		[JsonPropertyName("quantity")]
		public int Quantity { get; set; }

		[JsonPropertyName("meta_name")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string MetaName { get; set; }

		[JsonPropertyName("expansion_code")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string ExpansionCode { get; set; }

		[JsonPropertyName("collector_number")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string CollectorNumber { get; set; }

		[JsonPropertyName("language")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string Language { get; set; }

		[JsonPropertyName("condition")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string Condition { get; set; }

		[JsonPropertyName("foil")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string Foil { get; set; }

		[JsonPropertyName("reverse")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string Reverse { get; set; }

		[JsonPropertyName("first_edition")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public bool? FirstEdition { get; set; }
	}
}
