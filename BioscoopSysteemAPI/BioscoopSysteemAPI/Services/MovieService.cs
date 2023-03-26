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
                if (filterDTO.genre != null && movie.Genre != filterDTO.genre.ToString())
                {
                    check = false;
                }
                if (filterDTO.search != null && !movie.Name.ToLower().Contains(filterDTO.search.ToLower()))
                {
                    check = false;
                }
                if (filterDTO.age != null && movie.AllowedAge > filterDTO.age)
				{
					check = false;
				}
                if (filterDTO.subtitles != null && movie.Subtitles != filterDTO.subtitles)
                {
                    check = false;
                }
                if (filterDTO.threeDee != null && movie.Add3DMovie != filterDTO.threeDee)
				{
					check = false;
				}
                if (filterDTO.specials != null && movie.Specials != filterDTO.specials.ToString())
                {
                    check = false;
                }
                if (filterDTO.language != null && movie.Language != filterDTO.language)
                {
                    check = false;
                }


                if (check)
				{
					moviesToAdd.Add(movie);
				}
            }
			return moviesToAdd;

		}
    }
}
