using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Inventory
{
	public class ProductCreateBulkRequest
	{
		[JsonPropertyName("products")]
		public IEnumerable<ProductCreateRequest> Products { get; set; }
	}
}