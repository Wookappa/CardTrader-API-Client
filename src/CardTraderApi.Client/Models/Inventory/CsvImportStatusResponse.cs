using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Inventory
{
	public class CsvImportStatusResponse
	{
		[JsonPropertyName("id")]
		public int Id { get; set; }

		[JsonPropertyName("count")]
		public int Count { get; set; }

		[JsonPropertyName("imported_count")]
		public int ImportedCount { get; set; }

		[JsonPropertyName("skipped_count")]
		public int SkippedCount { get; set; }

		[JsonPropertyName("create_count")]
		public int CreateCount { get; set; }

		[JsonPropertyName("update_count")]
		public int UpdateCount { get; set; }

		[JsonPropertyName("delete_count")]
		public int DeleteCount { get; set; }

		[JsonPropertyName("error")]
		public string Error { get; set; }

		[JsonPropertyName("sync_started_at")]
		public DateTime? SyncStartedAt { get; set; }

		[JsonPropertyName("sync_ended_at")]
		public DateTime? SyncEndedAt { get; set; }

		[JsonPropertyName("csv_filename")]
		public string CsvFilename { get; set; }

		[JsonPropertyName("csv_size")]
		public int CsvSize { get; set; }
	}
}
