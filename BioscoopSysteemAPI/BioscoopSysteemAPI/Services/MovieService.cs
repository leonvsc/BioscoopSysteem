using BioscoopSysteemAPI.Models;
using BioscoopSysteemAPI.Dal.Repository;
using System;
using BioscoopSysteemAPI.DTOs;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Collections;
using BioscoopSysteemAPI.Interfaces;

namespace BioscoopSysteemAPI.Service
{
	public class MovieService
	{

        public MovieService()
        {
		}	

		public List<Movie> GetFilteredMovie(FilterDTO filterDTO,List<Movie> movies)
		{
            List<Movie> moviesToAdd = new List<Movie>() ;
            //var movies = _movieRepository.GetMoviesList();
            if (!movies.Any())
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
