using BioscoopSysteemAPI.Models;
using BioscoopSysteemAPI.Repository;
using System;


namespace BioscoopSysteemAPI.Service
{
	public class MovieService
	{
		private readonly MovieRepository movieRepository;

		public MovieService(MovieRepository movieRepository)
		{
			this.movieRepository = movieRepository;
		}

		public IEnumerable<Movie> GetMovies()
		{
			var movies = this.movieRepository.GetMovies();
			if(movies != null)
            {
				return movies;
            }
			return null;
		}


		public Movie GetMovie(int id)
        {
			var movie = this.movieRepository.getMovie(id);
			if(movie != null)
            {
				return movie;
            }
			return null;
        }		
		
		public Movie Delete(int id)
		{
			var movies = this.movieRepository.DeleteMovie(id);
			if(movies != null)
            {
				return movies;
            }
			return null;
		}


		public Movie Update(int id)
        {
			var movie = this.movieRepository.UpdateMovie(id);
			if(movie != null)
            {
				return movie;
            }
			return null;
        }
		
		public Movie Add(Movie movie)
        {
			var movie = this.movieRepository.AddMovie(movie);
			if(movie != null)
            {
				return movie;
            }
			return null;
		}
	}
}
