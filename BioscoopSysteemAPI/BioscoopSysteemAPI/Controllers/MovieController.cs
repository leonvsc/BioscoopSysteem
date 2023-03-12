using System.Net.Mime;
using AutoMapper;
using BioscoopSysteemAPI.DTOs.MovieDTOs;
using BioscoopSysteemAPI.Interfaces;
using BioscoopSysteemAPI.Models;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BioscoopSysteemAPI.Controllers
{
    [Route("api/movies")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class MovieController : ControllerBase
    {
        
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieController(IMovieRepository movieRepository, IMapper mapper )
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        // GET: api/movies
        /// <summary>
        /// Get all movies.
        /// </summary>
        /// <response code="200">Succesfully returns a movie object.</response>
        /// <returns>A list of movie objects.</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieReadDTO>>> GetMovies()
        {
            try
            {
                var domainMovies = await _movieRepository.GetMoviesAsync();

                if (domainMovies == null)
                {
                    return NotFound();
                }

                var dtoMovies = _mapper.Map<List<MovieReadDTO>>(domainMovies.Value);

                return Ok(dtoMovies);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        // GET: api/movies/1
        /// <summary>
        /// Get a movie by ID.
        /// </summary>
        /// <param name="id">Id of the movie.</param>
        /// <returns>A movie object.</returns>
        /// <response code="200">Succesfully returns a movie object.</response>
        /// <response code="404">Error: The object you are looking for is not found.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieReadDTO>> GetMovie(int id)
        {
            try
            {
                var domainMovie = await _movieRepository.GetMovieByIdAsync(id);
                var dtoMovie = _mapper.Map<MovieReadDTO>(domainMovie.Value);

                if (dtoMovie == null)
                {
                    return NotFound();
                }
                return Ok(dtoMovie);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        // DELETE: api/movies/1
        /// <summary>
        /// Delete an object by Id in the database.
        /// </summary>
        /// <param name="id">Id of the object.</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<MovieDeleteDTO>> DeleteMovie(int id)
        {
            try
            {
                var movie = await _movieRepository.DeleteMovieAsync(id);

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

        /// <summary>
        /// Update a movie.
        /// </summary>
        /// <param name="id">Id of the movie</param>
        /// <param name="movie">Movie object</param>
        /// <returns>Action result without content.</returns>
        /// <response code="204">Succesfully updated object.</response>
        /// <response code="404">Error: The object you are looking for is not found.</response>
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public async Task<ActionResult<Movie>> PutMovie(int id, Movie movie)
        {

            if (id != movie.MovieId)
            {
                return BadRequest();
            }

            try
            {
                var domainMovie = await _movieRepository.PutMovieAsync(id, movie);

                if (domainMovie == null)
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

        // POST: api/movies
        /// <summary>
        /// Creates a new movie object.
        /// </summary>
        /// <param name="payment">A movie object.</param>
        /// <returns>The new movie object.</returns>
        /// <response code="201">Succesfully created object.</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<ActionResult<MovieCreateDTO>> PostMovie(MovieCreateDTO movieDto)
        {
            try
            {
                var domainMovie = _mapper.Map<Movie>(movieDto);

                if (domainMovie == null)
                {
                    return NoContent();
                }

                int movieId = _movieRepository.PostMovieAsync(domainMovie).Id;

                return CreatedAtAction("GetMovie", new { id = movieId }, movieDto);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        /// <summary>
        /// Get all Rooms in a movie.
        /// </summary>
        /// <param name="id">Movie Id</param>
        /// <returns>A list of room objects.</returns>
        /// <response code="200">Succesfully returns the room objects.</response>
        /// <response code="400">Error: Response with this is a bad request.</response>
        /// <response code="404">Error: The object you are looking for is not found.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}/movie/rooms")]
        public async Task<ActionResult<Movie>> GetAllRoomsOfAMovie(int id)
        {
            var getAllRoomsOfAMovie = await _movieRepository.GetAllRoomsOfAMovie(id);

            if (getAllRoomsOfAMovie.Result == null)
            {
                return NotFound();
            }


            return Ok(getAllRoomsOfAMovie);
        }

    }
}




