using Microsoft.EntityFrameworkCore;
using StarWarsMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsMovies.Data
{
    public class StarWarsDbContext : DbContext
    {
        public StarWarsDbContext(DbContextOptions<StarWarsDbContext> options): base(options)
        {

        }

        public DbSet<EpisodesRating> Rating { get; set; }
    }
}
