using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using StarWarsMovies.Controllers;
using StarWarsMovies.Data;
using StarWarsMovies.Managers;
using StarWarsMovies.Models;
using System;
using Xunit;

namespace StarWarsMoviesTests
{
    public class FilmsControllerTest
    {
        [Fact]
        public void Test1()
        {
            var options = new DbContextOptionsBuilder<StarWarsDbContext>().UseInMemoryDatabase(databaseName: "StarWarsDatabase").Options;
            var _mockRepo2 = new Mock<IFilmsManager>();
            using (var context = new StarWarsDbContext(options))
            {
                context.Rating.Add(new EpisodesRating { Id = 1, EpisodeId = 2, Score = EScoreType.Good });
                context.Rating.Add(new EpisodesRating { Id = 2, EpisodeId = 5, Score = EScoreType.Excellent });
                context.SaveChanges();
                var controller = new FilmController(_mockRepo2.Object, context);
                var result = controller.Index();
                Assert.IsType<ViewResult>(result);
            }
        }
    }
}
