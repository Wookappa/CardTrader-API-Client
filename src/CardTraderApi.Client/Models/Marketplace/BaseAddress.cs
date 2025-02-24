using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Marketplace
{
	public class BaseAddress
	{
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
	}
}
