using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Inventory
{
	public abstract class BaseProduct
	{
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[JsonPropertyName("blueprint_id")]
		public int BlueprintId { get; set; }

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[JsonPropertyName("quantity")]
		public int Quantity { get; set; }

		[JsonPropertyName("description")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string Description { get; set; }

		[JsonPropertyName("user_data_field")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string UserDataField { get; set; }

		[JsonPropertyName("graded")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public bool Graded { get; set; }

		[JsonPropertyName("error_mode")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string ErrorMode { get; set; } // "strict" or "loose"

		[JsonPropertyName("properties")]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public Properties Properties { get; set; }
	}
}
