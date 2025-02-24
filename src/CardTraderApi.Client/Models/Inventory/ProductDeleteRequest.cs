using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Inventory
{
	public class ProductDeleteRequest
	{
		[JsonPropertyName("id")]
		public int Id { get; set; }
	}
}
