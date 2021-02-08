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
        Disappointing = 2,
        Good= 3,
        Excellent = 4,
        Masterpiece =5
    }
}
