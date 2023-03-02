using BioscoopSysteemAPI.Models;
using BioscoopSysteemAPI.Dal.Repository;
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

		public async Task <IEnumerable<Movie>> GetMovies()
		{
			var movies = await this.movieRepository.GetMovies();
			if(movies != null)
            {
				return movies;
            }
			return null;
		}


		public async Task <Movie> GetMovie(int id)
        {
			var movie = await this.movieRepository.GetMovieById(id);
			if(movie != null)
            {
				return movie;
            }
			return null;
        }		
		
		public async Task <Movie> Delete(int id)
		{
			var movies = await this.movieRepository.DeleteMovie(id);
			if(movies != null)
            {
				return movies;
            }
			return null;
		}


		public async Task<Movie> Update(int id)
        {
			var movie = await this.movieRepository.UpdateMovie(id);
			if(movie != null)
            {
				return movie;
            }
			return null;
        }
		
		public async Task<Movie> Add(Movie movieInput)
        {
			var movie = await this.movieRepository.AddMovie(movieInput);
			if(movie != null)
            {
				return movie;
            }
			return null;
		}
	}
}
