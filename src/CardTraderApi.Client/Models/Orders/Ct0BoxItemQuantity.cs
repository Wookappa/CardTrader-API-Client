using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Orders
{
	public class Ct0BoxItemQuantity
	{
		[JsonPropertyName("ok")]
		public int? Ok { get; set; }

		[JsonPropertyName("pending")]
		public int? Pending { get; set; }

		[JsonPropertyName("missing")]
		public int? Missing { get; set; }
	}
}
