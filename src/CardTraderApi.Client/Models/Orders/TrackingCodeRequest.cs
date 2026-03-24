using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Orders
{
	public class TrackingCodeRequest
	{
		[JsonPropertyName("tracking_code")]
		public string TrackingCode { get; set; }
	}
}
