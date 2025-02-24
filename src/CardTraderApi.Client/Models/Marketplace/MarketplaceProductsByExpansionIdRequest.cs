using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Marketplace
{
	public class MarketplaceProductsByExpansionIdRequest : MarketplaceProductsBaseRequest
	{
		[JsonPropertyName("expansion_id")]
		public int ExpansionId { get; set; }
	}
}
