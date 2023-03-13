using BioscoopSysteemAPI.Models;
using BioscoopSysteemAPI.Dal.Repository;
using System;
using BioscoopSysteemAPI.DTOs;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Collections;

namespace BioscoopSysteemAPI.Service
{
	public class MovieService
	{
		private readonly MovieRepository movieRepository;

        public MovieService(MovieRepository movieRepository)

        {
            this.movieRepository = 
		}	

		public List<Movie> GetFilteredMovie(FilterDTO filterDTO)
		{
            List<Movie> moviesToAdd = new List<Movie>() ;
            var movies = movieRepository.GetMoviesList();
            if (movies == null)
            {
                return null;
            }
            foreach (Movie movie in movies)
			{
				var check = true;
                /*	if (filterDTO.genre != null && movie.placeholder != filterDTO.genre)
                    {
                        check = false;
                    }*/
                if (filterDTO.search != null && !movie.Name.Contains(filterDTO.search))
                {
                    check = false;
                }
                if (filterDTO.age != null && movie.AllowedAge > filterDTO.age)
				{
					check = false;
				}
				if (filterDTO.threeDee != null && movie.Add3DMovie != filterDTO.threeDee)
				{
					check = false;
				}
		/*		if (filterDTO.specials != null && movie.placeholder != filterDTO.specials)
				{
					check = false;
				}*/
				if (check)
				{
					moviesToAdd.Add(movie);
				}
            }
			return moviesToAdd;

		}
    }
}
