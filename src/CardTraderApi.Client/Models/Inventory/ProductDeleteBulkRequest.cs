using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Inventory
{
	public class ProductDeleteBulkRequest
	{
		[JsonPropertyName("products")]
		public IEnumerable<ProductDeleteRequest> Products { get; set; }
	}
}