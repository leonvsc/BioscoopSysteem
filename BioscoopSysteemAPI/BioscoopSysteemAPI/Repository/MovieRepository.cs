using System;
using BioscoopSysteemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BioscoopSysteemAPI.Repository
{
	public class MovieRepository
	{
        private readonly CinemaDbContext cinemaDbContext;

        public MovieRepository(CinemaDbContext cinemaDbContext)
		{
            this.cinemaDbContext = cinemaDbContext;
        }

        public async Task<IEnumerable<Movie>> GetMovies()
        {
            var movies = await cinemaDbContext.Movies.ToListAsync();
            return movies;
        }

        public async Task<Movie> GetMovieById(int id)
        {
            var movie = await cinemaDbContext.Movies.FindAsync(id);
            return movie;
        }

        public async Task<Movie> AddMovie(Movie movie)
        {
            var cinemaMovie = await (from Movie in this.cinemaDbContext.Movies
                                     select new Movie
                                     {
                                         MovieId = movie.MovieId,
                                         Name = movie.Name,
                                         Description = movie.Description,
                                         Price = movie.Price,
                                         AllowedAge = movie.AllowedAge,
                                         ImageUrl = movie.ImageUrl,
                                         RoomId = movie.RoomId

                                     }).SingleOrDefaultAsync();

            if (cinemaMovie != null)
            {
                var result = await cinemaDbContext.Movies.AddAsync(cinemaMovie);
                await cinemaDbContext.SaveChangesAsync();
                return result.Entity;
            }
            return null;
        }

        public async Task<Movie> DeleteMovie(int id)
        {
            var movie = await cinemaDbContext.Movies.FindAsync(id);

            if (movie != null)
            {
                cinemaDbContext.Movies.Remove(movie);
                await cinemaDbContext.SaveChangesAsync();
            }
            return movie;
        }

        public async Task<Movie> UpdateMovie(int id) 
        {
            var movie = await cinemaDbContext.Movies.FindAsync(id);

            if (movie != null)
            {
                cinemaDbContext.Movies.Update(movie);
                await cinemaDbContext.SaveChangesAsync();
                return movie;
            }
            return null;
        }
	}
}

