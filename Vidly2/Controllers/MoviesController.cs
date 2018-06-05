using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;
using System.Data.Entity;

namespace Vidly2.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }


        // /movies
        [Route("movies")]
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }


        [Route("movies/release/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }


        [Route("movies/MovieDetails/{id}")]
        public ActionResult MovieDetails(int? id)
        {
            if (!id.HasValue)
            {
                return new RedirectResult("/movies");
            }
            else
            {
                Movie FoundMovie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
                if (FoundMovie != null)
                {
                    return View((Movie)FoundMovie);
                }
                else
                {
                    return new RedirectResult("/movies");
                }
            }
        }
    }
}