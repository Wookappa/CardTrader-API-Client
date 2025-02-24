using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Marketplace
{
	public class MarketplaceProductsByBlueprintIdRequest : MarketplaceProductsBaseRequest
	{
		[JsonPropertyName("blueprint_id")]
		public int BlueprintId { get; set; }
	}
}
