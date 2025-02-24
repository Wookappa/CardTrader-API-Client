using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Inventory
{
	public class ProductIncrementDecrementRequest
	{
		[JsonPropertyName("Id")]
		public int Id { get; set; }

		[JsonPropertyName("delta_quantity")]
		public int DeltaQuantity { get; set; }
	}
}
