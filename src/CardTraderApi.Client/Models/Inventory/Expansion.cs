using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Inventory
{
	public class Expansion
	{
		[JsonPropertyName("id")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public int Id { get; set; }

		[JsonPropertyName("game_id")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public int GameId { get; set; }

		[JsonPropertyName("code")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string Code { get; set; }

		[JsonPropertyName("name")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string Name { get; set; }

		[JsonPropertyName("name_en")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string NameEn { get; set; }
	}
}
