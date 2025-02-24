using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Inventory
{
	public class ProductUpdateRequest : BaseProduct
	{
		[JsonPropertyName("id")]
		public int Id { get; set; }

		[JsonPropertyName("price")]
		public decimal Price { get; set; }
	}
}