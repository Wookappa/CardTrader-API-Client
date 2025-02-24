using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Inventory
{
	public class Properties
	{
		[JsonPropertyName("mtg_language")]
		public string MtgLanguage { get; set; }

		[JsonPropertyName("mtg_foil")]
		public bool MtgFoil { get; set; }

		[JsonPropertyName("condition")]
		public string Condition { get; set; }

		[JsonPropertyName("signed")]
		public bool Signed { get; set; }

		[JsonPropertyName("altered")]
		public bool Altered { get; set; }
	}
}
