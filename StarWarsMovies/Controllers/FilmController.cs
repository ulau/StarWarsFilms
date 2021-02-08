using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StarWarsMovies.Data;
using StarWarsMovies.Managers;
using StarWarsMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsMovies.Controllers
{
    public class FilmController : Controller
    {
        private readonly IFilmsManager _filmsManager;
        private readonly StarWarsDbContext _db;

        public FilmController(IFilmsManager filmsManager, StarWarsDbContext db)
        {
            _filmsManager = filmsManager;
            _db = db;
        }
        /// <summary>
        /// Show the list of films
        /// </summary>
        /// <returns>List with episodes titles</returns>
        public IActionResult Index()
        {
            var filmslist = _filmsManager.GetFilms();
            return View(filmslist);
        }
        /// <summary>
        /// Show details of chosen film
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Main information about episode</returns>
        public IActionResult FilmDetails(int? id)
        {
            if(!id.HasValue)
            {
                return NotFound();
            }
            var filmDetails = _filmsManager.GetFilm(id.Value + 1);
            if (filmDetails == null)
            {
                return NotFound();
            }
            var filmRating = _db.Rating.Where(x => x.EpisodeId == filmDetails.EpisodeId).ToList();
            if(filmRating.Count > 0)
            {
                filmDetails.Rating = filmRating.Average(f => (int)f.Score);
            }
            return View(filmDetails);
        }
        /// <summary>
        /// Select film to evaluate
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <returns>List of scores for evaluation</returns>
        public IActionResult Evaluate(int? id, string title)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }
            var rating = new EpisodesRating { EpisodeId = id.Value };
            ViewBag.Title = title;
            return View(rating);
        }
        /// <summary>
        /// Add rating of chosen film
        /// </summary>
        /// <param name="rating"></param>
        /// <returns>Save rating and display list of episodes</returns>
        [HttpPost]
        public IActionResult EvaluatePost(EpisodesRating rating)
        {
            if (ModelState.IsValid)
            {
                _db.Rating.Add(rating);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rating);
        }
    }
}
