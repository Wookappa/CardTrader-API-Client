using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Inventory
{
	public class JobResponse
	{
		[JsonPropertyName("job")]
		public string Job { get; set; }
	}
}
