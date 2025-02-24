using CardTraderApi.Client.Models.Common;
using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Inventory
{
	public class Product : BaseProduct
	{
		[JsonPropertyName("uploaded_images")]
		public UploadedImage[] UploadedImages { get; set; }

		[JsonPropertyName("price_cents")]
		public int PriceCents { get; set; }

		[JsonPropertyName("properties_hash")]
		public PropertiesHash PropertiesHash { get; set; }

		[JsonPropertyName("expansion")]
		public ExpansionReference Expansion { get; set; }

		[JsonPropertyName("category_id")]
		public int CategoryId { get; set; }

		[JsonPropertyName("user_id")]
		public int UserId { get; set; }

		[JsonPropertyName("id")]
		public int Id { get; set; }

		[JsonPropertyName("tag")]
		public string Tag { get; set; }

		[JsonPropertyName("bundle_size")]
		public int BundleSize { get; set; }

		[JsonPropertyName("price_currency")]
		public string PriceCurrency { get; set; }

		[JsonPropertyName("game_id")]
		public int GameId { get; set; }

		[JsonPropertyName("name_en")]
		public string NameEn { get; set; }
	}

	public class UploadedImage
	{
		// Add properties if needed, otherwise it can be left empty
	}
}
