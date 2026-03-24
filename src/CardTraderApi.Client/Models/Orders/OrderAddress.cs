using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Orders
{
	public class OrderAddress
	{
		[JsonPropertyName("id")]
		public int Id { get; set; }

		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("street")]
		public string Street { get; set; }

		[JsonPropertyName("zip")]
		public string Zip { get; set; }

		[JsonPropertyName("city")]
		public string City { get; set; }

		[JsonPropertyName("state_or_province")]
		public string StateOrProvince { get; set; }

		[JsonPropertyName("country_code")]
		public string CountryCode { get; set; }

		[JsonPropertyName("country")]
		public string Country { get; set; }

		[JsonPropertyName("note")]
		public string Note { get; set; }

		[JsonPropertyName("created_at")]
		public DateTime? CreatedAt { get; set; }

		[JsonPropertyName("updated_at")]
		public DateTime? UpdatedAt { get; set; }
	}
}
