using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Marketplace
{
	public class Address : BaseAddress
	{
		[JsonPropertyName("id")]
		public int Id { get; set; }

		[JsonPropertyName("user_id")]
		public int UserId { get; set; }

		[JsonPropertyName("phone")]
		public string Phone { get; set; }

		[JsonPropertyName("keep_original")]
		public bool KeepOriginal { get; set; }

		[JsonPropertyName("default_billing_address")]
		public bool DefaultBillingAddress { get; set; }

		[JsonPropertyName("default_shipping_address")]
		public bool DefaultShippingAddress { get; set; }

		[JsonPropertyName("note")]
		public string Note { get; set; }

		[JsonPropertyName("created_at")]
		public DateTime CreatedAt { get; set; }

		[JsonPropertyName("updated_at")]
		public DateTime UpdatedAt { get; set; }
	}
}
