using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;
using System.Data.Entity;
using Vidly2.ViewModels;

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


        public ActionResult SaveMovie(MovieFormViewModel viewModel)
        {
            Movie movie = viewModel.Movie;
            if(movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                Movie movieToDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieToDb.Name = movie.Name;
                movieToDb.ReleaseDate = movie.ReleaseDate;
                movieToDb.GenreTypeId = movie.GenreTypeId;
                movieToDb.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        [Route("movies/newmovie")]
        public ActionResult NewMovie()
        {
            var Genres = _context.Genres.ToList();
            MovieFormViewModel viewModel = new MovieFormViewModel
            {
                Genre = Genres
            };

            return View("MovieForm",viewModel);
        }


        public ActionResult EditMovie(int id)
        {
            Movie movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound("The selected Moview was not found in the database");

            MovieFormViewModel viewModel = new MovieFormViewModel
            {
                Genre = _context.Genres.ToList(),
                Movie = movie

            };

            return View("MovieForm", viewModel);
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


//[Route("movies/release/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
//public ActionResult ByReleaseDate(int year, int month)
//{
//    return Content(year + "/" + month);
//}