using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Marketplace
{
	public class MarketplaceProductsBaseRequest
	{
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[JsonPropertyName("foil")]
		public bool Foil { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		[JsonPropertyName("language")]
		public string Language { get; set; }
	}
}
