using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Inventory
{
	public class JobResult
	{
		[JsonPropertyName("uuid")]
		public Guid Uuid { get; set; }

		[JsonPropertyName("state")]
		public string State { get; set; }

		[JsonPropertyName("spawned_children")]
		public int SpawnedChildren { get; set; }

		[JsonPropertyName("results")]
		public List<JobResultItem> Results { get; set; }

		[JsonPropertyName("stats")]
		public JobStats Stats { get; set; }

		[JsonPropertyName("started_at")]
		public DateTime StartedAt { get; set; }

		[JsonPropertyName("ended_at")]
		public DateTime EndedAt { get; set; }

		[JsonPropertyName("duration")]
		public double Duration { get; set; }
	}

	public class JobResultItem
	{
		[JsonPropertyName("result")]
		public string Result { get; set; }

		[JsonPropertyName("job_index")]
		public int JobIndex { get; set; }

		[JsonPropertyName("product_id")]
		public int ProductId { get; set; }

		[JsonPropertyName("warnings")]
		public JobWarnings Warnings { get; set; }
	}

	public class JobWarnings
	{
		[JsonPropertyName("properties")]
		public WarningsProperties Properties { get; set; }
	}

	public class WarningsProperties
	{
		[JsonPropertyName("condition")]
		public List<string> Condition { get; set; }
	}

	public class JobStats
	{
		[JsonPropertyName("ok")]
		public int Ok { get; set; }

		[JsonPropertyName("warning")]
		public int Warning { get; set; }

		[JsonPropertyName("error")]
		public int Error { get; set; }
	}
}