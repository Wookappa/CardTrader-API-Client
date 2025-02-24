using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Inventory
{
	public class ProductResponse
	{
		[JsonPropertyName("result")]
		public string Result { get; set; }

		[JsonPropertyName("warnings")]
		[JsonConverter(typeof(WarningsConverter))]
		public Warnings Warnings { get; set; }

		[JsonPropertyName("resource")]
		public Resource Resource { get; set; }
	}
}
