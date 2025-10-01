using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CardTraderApi.Client.Models.Marketplace
{
    public class Game
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class GameListResponse
    {
        [JsonPropertyName("array")]
        public List<Game> Array { get; set; }
    }
}