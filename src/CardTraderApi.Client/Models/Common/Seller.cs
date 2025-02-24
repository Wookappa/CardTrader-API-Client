using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Common
{
	public class Seller
	{
		[JsonPropertyName("id")]
		public int Id { get; set; }

		[JsonPropertyName("username")]
		public string Username { get; set; }
	}
}
