using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models;

public class Error : BaseItem
{
	[JsonPropertyName("error_code")]
	public string Code { get; set; }

	[JsonPropertyName("errors")]
	public string[] Errors { get; set; }

	[JsonPropertyName("request_id")]
	public string RequestId { get; set; }

	[JsonPropertyName("extra")]
	public Message Extra { get; set; }
}


