using System;
using System.Net.Http.Json;
using BioscoopSysteemAPI.DTOs;
using BioscoopSysteemAPI.DTOs.MovieDTOs;
using BioscoopSysteemWeb.Service.Contracts;
using static System.Net.WebRequestMethods;

namespace BioscoopSysteemWeb.Service
{
	public class MovieService : IMovieService
	{

        private readonly HttpClient _httpClient;

        public MovieService(HttpClient httpClient)
		{
            this._httpClient = httpClient;
        }


        public async Task<IEnumerable<MovieReadDTO>> GetMovies()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/movies");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<MovieReadDTO>();
                    }
                    return await response.Content.ReadFromJsonAsync<IEnumerable<MovieReadDTO>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<MovieReadDTO>> GetMovieByFilter(FilterDTO filter )
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/movies/filter", filter);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<MovieReadDTO>();
                    }
                    return await response.Content.ReadFromJsonAsync<IEnumerable<MovieReadDTO>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<MovieReadDTO> GetMovie(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/movies/{id}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(MovieReadDTO);
                        
                    }
                    return await response.Content.ReadFromJsonAsync<MovieReadDTO>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

