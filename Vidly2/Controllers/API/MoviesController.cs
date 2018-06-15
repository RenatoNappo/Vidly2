using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly2.Models;
using AutoMapper;
using Vidly2.DTOs;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace Vidly2.Controllers.API
{
    public class MoviesController : ApiController
    {

        private ApplicationDbContext _context;


        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }


        // GET api/movies
        [HttpGet]
        public IHttpActionResult GetMovies()
        {
            var movieDtos = _context.Movies
                            .Include(m => m.Genre)
                            .ToList()
                            .Select(Mapper.Map<Movie, MovieDTO>);

            return Ok(movieDtos);
        }


        // GET api/movies/{id}
        [HttpGet]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDTO>(movie));
        }

        
        // POST api/movies
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateMovie(MovieDTO moviedto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieToAdd = Mapper.Map<MovieDTO, Movie>(moviedto);
            _context.Movies.Add(movieToAdd);
            _context.SaveChanges();

            moviedto.Id = movieToAdd.Id;

            return Created(new Uri(Request.RequestUri + "/" + movieToAdd.Id), moviedto);
        }


        // PUT api/movies/{id}
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult UpdateMovie(int id, MovieDTO moviedto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                return NotFound();

            Mapper.Map(moviedto, movieInDb);
            _context.SaveChanges();
            return Ok(moviedto);
        }

        
        // DELETE api/movies{id}
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieToRemove = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieToRemove == null)
                return NotFound();

            _context.Movies.Remove(movieToRemove);
            _context.SaveChanges();
            return Ok();
        }

    }
}
