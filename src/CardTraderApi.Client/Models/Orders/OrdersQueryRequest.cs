using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Orders
{
	public class OrdersQueryRequest
	{
		[JsonPropertyName("page")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public int Page { get; set; }

		[JsonPropertyName("limit")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public int Limit { get; set; }

		[JsonPropertyName("from")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string From { get; set; }

		[JsonPropertyName("to")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string To { get; set; }

		[JsonPropertyName("from_id")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public int FromId { get; set; }

		[JsonPropertyName("to_id")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public int ToId { get; set; }

		[JsonPropertyName("state")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string State { get; set; }

		[JsonPropertyName("order_as")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string OrderAs { get; set; }

		[JsonPropertyName("sort")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string Sort { get; set; }
	}
}
