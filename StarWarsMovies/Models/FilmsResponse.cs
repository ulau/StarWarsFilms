using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StarWarsMovies.Models
{
    public class FilmsResponse
    {
        [JsonPropertyName("results")]
        public List<Film> FilmsList { get; set; }
    }
}
