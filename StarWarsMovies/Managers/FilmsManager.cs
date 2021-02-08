using Microsoft.Extensions.Options;
using StarWarsMovies.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;

namespace StarWarsMovies.Managers
{
    public class FilmsManager : IFilmsManager
    {
        private ApiSettings _mySettings { get; set; }
        public FilmsManager(IOptions<ApiSettings> settings)
        {
            _mySettings = settings.Value;
        }

        /// <summary>
        /// Get all film
        /// </summary>
        /// <returns>List of available titles</returns>
        public List<Film> GetFilms()
        {
            var url = _mySettings.Url;

            using (var client = new HttpClient())
            {
                var response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    var filmsResponse = JsonSerializer.Deserialize<FilmsResponse>(json);
                    return filmsResponse.FilmsList;
                }
                return null;
            }
        }
        /// <summary>
        /// Get film chosen from the list
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Main information about episode</returns>
        public FilmDetails GetFilm(int id)
        {
            var url = string.Format("{0}{1}/", _mySettings.Url, id);
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    var filmDetails = JsonSerializer.Deserialize<FilmDetails>(json);
                    return filmDetails;
                }
                return null;
            }
        }
    }
}
