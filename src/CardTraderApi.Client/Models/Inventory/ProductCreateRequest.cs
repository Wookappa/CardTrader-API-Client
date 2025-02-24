using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Inventory
{
	public class ProductCreateRequest : BaseProduct
	{
		[JsonPropertyName("price")]
		public decimal Price { get; set; }
	}
}