using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models;

public abstract class BaseItem
{
	[JsonPropertyName("object")]
	public string ObjectType { get; set; }
}