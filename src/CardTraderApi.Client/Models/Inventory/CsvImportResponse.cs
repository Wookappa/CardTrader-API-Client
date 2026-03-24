using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Inventory
{
	public class CsvImportResponse
	{
		[JsonPropertyName("id")]
		public int Id { get; set; }

		[JsonPropertyName("csv_filename")]
		public string CsvFilename { get; set; }

		[JsonPropertyName("csv_size")]
		public int CsvSize { get; set; }
	}
}
