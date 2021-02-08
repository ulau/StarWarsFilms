using System.ComponentModel.DataAnnotations;

namespace StarWarsMovies.Models
{
    public class EpisodesRating
    {
        [Key]
        public int Id { get; set; }
        public int EpisodeId { get; set; }
        public EScoreType Score { get; set; }
    }

    public enum EScoreType
    {
        Failure = 1,
        Regrettable = 2,
        Disappointing = 3,
        Mediocre = 4,
        Good = 5,
        Great = 6,
        Excellent = 7,
        Exceptional = 8,        
        Masterpiece = 9,
        Favorite = 10
    }
}
