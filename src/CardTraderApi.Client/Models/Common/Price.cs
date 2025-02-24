using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Common
{
	public class Price
	{
		[JsonPropertyName("cents")]
		public int Cents { get; set; }

		[JsonPropertyName("currency")]
		public string Currency { get; set; }

		[JsonPropertyName("currency_symbol")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string CurrencySymbol { get; set; }

		[JsonPropertyName("formatted")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string Formatted { get; set; }
	}
}
