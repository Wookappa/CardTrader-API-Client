using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Marketplace
{
    public class Expansion
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("game_id")]
        public int GameId { get; set; }
        [JsonPropertyName("code")]
        public string Code { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}