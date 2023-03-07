using System;
using System.Net.Http.Json;
using BioscoopSysteemAPI.DTOs.MovieDTOs;
using BioscoopSysteemWeb.Service.Contracts;

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
                var respone = await _httpClient.GetAsync("api/movies");

                if (respone.IsSuccessStatusCode)
                {
                    if (respone.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<MovieReadDTO>();
                    }
                    return await respone.Content.ReadFromJsonAsync<IEnumerable<MovieReadDTO>>();
                }
                else
                {
                    var message = await respone.Content.ReadAsStringAsync();
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
                var respone = await _httpClient.GetAsync($"api/movies/{id}");

                if (respone.IsSuccessStatusCode)
                {
                    if (respone.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(MovieReadDTO);
                    }
                    return await respone.Content.ReadFromJsonAsync<MovieReadDTO>();
                }
                else
                {
                    var message = await respone.Content.ReadAsStringAsync();
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

