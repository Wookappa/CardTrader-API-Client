using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Orders
{
	public class OrderUser
	{
		[JsonPropertyName("id")]
		public int Id { get; set; }

		[JsonPropertyName("username")]
		public string Username { get; set; }

		[JsonPropertyName("email")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string Email { get; set; }

		[JsonPropertyName("phone")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string Phone { get; set; }
	}
}
