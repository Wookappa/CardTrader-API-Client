using CardTraderApi.Client.Models.Common;
using CardTraderApi.Client.Models.Inventory;
using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Marketplace
{
	public class CardItem
	{
		[JsonPropertyName("id")]
		public long Id { get; set; }

		[JsonPropertyName("blueprint_id")]
		public int BlueprintId { get; set; }

		[JsonPropertyName("name_en")]
		public string NameEn { get; set; }

		[JsonPropertyName("expansion")]
		public Expansion Expansion { get; set; }

		[JsonPropertyName("price_cents")]
		public int PriceCents { get; set; }

		[JsonPropertyName("price_currency")]
		public string PriceCurrency { get; set; }

		[JsonPropertyName("quantity")]
		public int Quantity { get; set; }

		[JsonPropertyName("description")]
		public string Description { get; set; }

		[JsonPropertyName("properties_hash")]
		public PropertiesHash PropertiesHash { get; set; }

		[JsonPropertyName("graded")]
		public object Graded { get; set; }

		[JsonPropertyName("bundle_size")]
		public int BundleSize { get; set; }

		[JsonPropertyName("on_vacation")]
		public bool OnVacation { get; set; }

		[JsonPropertyName("user")]
		public User User { get; set; }

		[JsonPropertyName("price")]
		public Price Price { get; set; }
	}
}
