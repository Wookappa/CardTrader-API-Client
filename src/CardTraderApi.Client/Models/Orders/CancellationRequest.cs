using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Orders
{
	public class CancellationRequest
	{
		[JsonPropertyName("relist_if_cancelled")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public bool RelistIfCancelled { get; set; }
	}
}
