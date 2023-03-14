using System;
using BioscoopSysteemAPI.Interfaces;
using BioscoopSysteemAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BioscoopSysteemAPI.Dal.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly CinemaDbContext _cinemaDbContext;


        public MovieRepository(CinemaDbContext cinemaDbContext)
        {
            this._cinemaDbContext = cinemaDbContext;
        }

        public  List<Movie> GetMoviesList()
        {
            List<Movie> movies =  _cinemaDbContext.Movies.ToList();
            if (movies.Any())
            {
                return movies;
            }
            return null;
        }

        public async Task<ActionResult<IEnumerable<Movie>>> GetMoviesAsync()
        {
            var movies = await _cinemaDbContext.Movies.ToListAsync();
            return movies;
        }

        public async Task<ActionResult<Movie>> GetMovieByIdAsync(int id)
        {
            var movie = await _cinemaDbContext.Movies.FindAsync(id);
            return movie;
        }
   
        public async Task<ActionResult<Movie>> PostMovieAsync(Movie movie) 
        {
            _cinemaDbContext.Movies.Add(movie);
            await _cinemaDbContext.SaveChangesAsync();

            return movie;
        }

        public async Task<ActionResult<Movie>> DeleteMovieAsync(int id)
        {
            var movie = await _cinemaDbContext.Movies.FindAsync(id);

            _cinemaDbContext.Movies.Remove(movie);
            await _cinemaDbContext.SaveChangesAsync();

            return movie;
        }

        public async Task<ActionResult<Movie>> PutMovieAsync(int id, Movie movie)
        {

            var domainMovie = _cinemaDbContext.Movies.Find(id);

            await _cinemaDbContext.SaveChangesAsync();

            return domainMovie;
        }
    }
}

