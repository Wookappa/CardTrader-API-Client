using System.Text.Json;
using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Inventory
{
	public class WarningsConverter : JsonConverter<Warnings>
	{
		public override Warnings Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.StartArray)
			{
				reader.Skip();
				return new Warnings();
			}

			if (reader.TokenType != JsonTokenType.StartObject)
			{
				throw new JsonException("Expected a JSON object or empty array for Warnings");
			}

			var warnings = new Warnings();
			reader.Read();

			while (reader.TokenType == JsonTokenType.PropertyName)
			{
				var propertyName = reader.GetString();
				reader.Read();

				// If value is an array of strings
				if (reader.TokenType == JsonTokenType.StartArray)
				{
					var values = JsonSerializer.Deserialize<List<string>>(ref reader, options);
					if (propertyName != null) warnings.Properties[propertyName] = values ?? [];
				}
				// If value is a single string
				else if (reader.TokenType == JsonTokenType.String)
				{
					if (propertyName != null) warnings.Properties[propertyName] = [reader.GetString()];
				}
				// If value is a nested object
				else if (reader.TokenType == JsonTokenType.StartObject)
				{
					var nestedObject = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(ref reader, options);
					foreach (var kvp in nestedObject)
					{
						warnings.Properties[kvp.Key] = kvp.Value;
					}
				}
				else
				{
					throw new JsonException($"Unexpected JSON token {reader.TokenType} for Warnings properties");
				}

				reader.Read();
			}

			return warnings;
		}

		public override void Write(Utf8JsonWriter writer, Warnings value, JsonSerializerOptions options)
		{
			writer.WriteStartObject();

			foreach (var kvp in value.Properties)
			{
				writer.WritePropertyName(kvp.Key);
				JsonSerializer.Serialize(writer, kvp.Value, options);
			}

			writer.WriteEndObject();
		}
	}
}
