using CardTraderApi.Client.Models.Common;
using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Inventory
{
	public class Resource : BaseProduct
	{
		[JsonPropertyName("id")]
		public int Id { get; set; }

		[JsonPropertyName("price")]
		public Price Price { get; set; }

		[JsonPropertyName("bundle_size")]
		public int BundleSize { get; set; }

		[JsonPropertyName("tag")]
		public string Tag { get; set; }

		[JsonPropertyName("game_id")]
		public int GameId { get; set; }

		[JsonPropertyName("category_id")]
		public int CategoryId { get; set; }

		[JsonPropertyName("expansion_id")]
		public int ExpansionId { get; set; }
	}
}