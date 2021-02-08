using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StarWarsMovies.Models
{
    public class FilmDetails : Film
    {
        [JsonPropertyName("opening_crawl")]
        public string OpeningCrawl { get; set; }
        [JsonPropertyName("director")]
        public string Director { get; set; }
        [JsonPropertyName("producer")]
        public string Producer { get; set; }
        [JsonPropertyName("release_date")]
        public string ReleaseDate { get; set; }
        [JsonIgnore]
        public double? Rating { get; set; }
    }
}
