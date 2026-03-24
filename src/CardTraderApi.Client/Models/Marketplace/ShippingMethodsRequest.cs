using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Marketplace
{
	public class ShippingMethodsRequest
	{
		[JsonPropertyName("username")]
		public string Username { get; set; }
	}
}
