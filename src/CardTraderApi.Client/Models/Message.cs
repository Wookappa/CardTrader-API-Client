using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models
{
	public class Message
	{
		[JsonPropertyName("message")]
		public string Content { get; set; }
	}
}
