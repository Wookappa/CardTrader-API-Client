using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Marketplace
{
	public class CartProduct
	{
		[JsonPropertyName("id")]
		public int Id { get; set; }

		[JsonPropertyName("name_en")]
		public string NameEn { get; set; }
	}
}
