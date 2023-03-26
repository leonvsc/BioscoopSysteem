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
            var domainMovie = await _cinemaDbContext.Movies.FindAsync(id);

            if (domainMovie == null)
            {
                return null;
            }

            domainMovie.MovieId = movie.MovieId;
            domainMovie.Name = movie.Name;
            domainMovie.Date = movie.Date;
            domainMovie.Add3DMovie = movie.Add3DMovie;
            domainMovie.Description = movie.Description;
            domainMovie.Price = movie.Price;
            domainMovie.AllowedAge = movie.AllowedAge;
            domainMovie.ImageUrl = movie.ImageUrl;
            domainMovie.Language = movie.Language;
            domainMovie.Subtitles = movie.Subtitles;
            domainMovie.Genre = movie.Genre;
            domainMovie.Specials = movie.Specials;

            await _cinemaDbContext.SaveChangesAsync();

            return domainMovie;
        }

        public async Task<IEnumerable<Room>> GetAllRoomsOfAMovieAsync(int id)
        {
            var getAllRoomsOfAMovie = await _cinemaDbContext.MovieRoom
                .Where(m => m.MovieId == id)
                .Select(m => m.Room)
                .ToListAsync();

            return getAllRoomsOfAMovie;
        }
    }
}

