using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Inventory
{
	public class Warnings
	{
		[JsonPropertyName("properties")]
		public Dictionary<string, IEnumerable<string>> Properties { get; set; } = new Dictionary<string, IEnumerable<string>>();
	}
}
