using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Webhooks
{
	public class WebhookPayload<T>
	{
		[JsonPropertyName("id")]
		public string Id { get; set; }

		[JsonPropertyName("time")]
		public long Time { get; set; }

		[JsonPropertyName("cause")]
		public string Cause { get; set; }

		[JsonPropertyName("object_class")]
		public string ObjectClass { get; set; }

		[JsonPropertyName("object_id")]
		public int ObjectId { get; set; }

		[JsonPropertyName("mode")]
		public string Mode { get; set; }

		[JsonPropertyName("data")]
		public T Data { get; set; }
	}
}
