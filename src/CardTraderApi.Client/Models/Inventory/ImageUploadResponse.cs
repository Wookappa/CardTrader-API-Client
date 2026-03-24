using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Inventory
{
	public class ImageUploadResponse
	{
		[JsonPropertyName("id")]
		public int Id { get; set; }
	}
}
