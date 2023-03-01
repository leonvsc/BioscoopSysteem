using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BioscoopSysteemAPI.Dal.Repository;
using BioscoopSysteemAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BioscoopSysteemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieRepository movieRepository;

        public MovieController(MovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            try
            {
                var movies = await this.movieRepository.GetMovies();

                if (movies == null)
                {
                    return NotFound();
                }
                return Ok(movies);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            try
            {
                var movie = await this.movieRepository.GetMovieById(id);

                if (movie == null)
                {
                    return BadRequest();
                }
                return Ok(movie);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Movie>> RemoveMovie(int id)
        {
            try
            {
                var movie = await this.movieRepository.DeleteMovie(id);

                if (movie == null)
                {
                    return NotFound();
                }
                return Ok(movie);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Movie>> UpdateMovie(int id)
        {
            try
            {
                var movie = await this.movieRepository.UpdateMovie(id);

                if (movie == null)
                {
                    return NotFound();
                }
                return Ok(movie);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> AddMovie([FromBody] Movie movie)
        {
            try
            {
                var cinemaMovie = await this.movieRepository.AddMovie(movie);

                if (cinemaMovie == null)
                {
                    return NoContent();
                }
                return Ok(cinemaMovie);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

    }
}




