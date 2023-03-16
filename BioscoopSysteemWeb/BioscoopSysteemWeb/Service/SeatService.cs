using System;
using System.Net.Http.Json;
using BioscoopSysteemAPI.DTOs;
using BioscoopSysteemAPI.DTOs.MovieDTOs;
using BioscoopSysteemAPI.DTOs.SeatDTOs;
using BioscoopSysteemWeb.Service.Contracts;

namespace BioscoopSysteemWeb.Service
{
	public class SeatService : ISeatService
	{

        private readonly HttpClient _httpClient;

        public SeatService(HttpClient httpClient)
		{
            this._httpClient = httpClient;
        }


        public async Task<IEnumerable<SeatReadDTO>> GetSeats()
        {
            try
            {
                var response = await _httpClient.GetAsync("/emptyseats");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<SeatReadDTO>();
                    }
                    return await response.Content.ReadFromJsonAsync<IEnumerable<SeatReadDTO>>();
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

