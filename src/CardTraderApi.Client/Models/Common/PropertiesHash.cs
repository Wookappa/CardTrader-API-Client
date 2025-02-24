using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Common
{
	public class PropertiesHash
	{
		[JsonPropertyName("condition")]
		public string Condition { get; set; }

		[JsonPropertyName("mtg_card_colors")]
		public string MtgCardColors { get; set; }

		[JsonPropertyName("collector_number")]
		public string CollectorNumber { get; set; }

		[JsonPropertyName("tournament_legal")]
		public bool TournamentLegal { get; set; }

		[JsonPropertyName("signed")]
		public bool Signed { get; set; }

		[JsonPropertyName("mtg_foil")]
		public bool MtgFoil { get; set; }

		[JsonPropertyName("mtg_rarity")]
		public string MtgRarity { get; set; }

		[JsonPropertyName("mtg_language")]
		public string MtgLanguage { get; set; }

		[JsonPropertyName("altered")]
		public bool Altered { get; set; }
	}
}
