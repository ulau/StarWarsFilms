using StarWarsMovies.Models;
using System.Collections.Generic;

namespace StarWarsMovies.Managers
{
    public interface IFilmsManager
    {
        List<Film> GetFilms();
        FilmDetails GetFilm(int id);
    }
}
