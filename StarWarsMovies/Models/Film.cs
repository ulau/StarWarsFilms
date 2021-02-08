using System.Text.Json.Serialization;

namespace StarWarsMovies.Models
{
    public class Film
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("episode_id")]
        public int EpisodeId { get; set; }
    }
}
