using System;
using BioscoopSysteemAPI.DTOs;
using BioscoopSysteemAPI.DTOs.MovieDTOs;


namespace BioscoopSysteemWeb.Service.Contracts
{
	public interface IMovieService
	{
		Task<IEnumerable<MovieReadDTO>> GetMovies();

		Task<MovieReadDTO> GetMovie(int id);

        Task<IEnumerable<MovieReadDTO>> GetMovieByFilter(FilterDTO filter);
	}
}

