using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Inventory
{
	public class ProductUpdateBulkRequest
	{
		[JsonPropertyName("products")]
		public IEnumerable<ProductUpdateRequest> Products { get; set; }
	}
}