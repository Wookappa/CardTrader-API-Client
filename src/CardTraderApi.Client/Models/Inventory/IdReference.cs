using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Inventory
{
	public class ExpansionReference
	{
		[JsonPropertyName("id")]
		public int Id { get; set; }
	}
}
