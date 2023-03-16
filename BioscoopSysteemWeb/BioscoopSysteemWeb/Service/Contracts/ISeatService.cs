using System;
using BioscoopSysteemAPI.DTOs;
using BioscoopSysteemAPI.DTOs.MovieDTOs;
using BioscoopSysteemAPI.DTOs.SeatDTOs;

namespace BioscoopSysteemWeb.Service.Contracts
{
	public interface ISeatService
	{
		Task<IEnumerable<SeatReadDTO>> GetSeats();

    }

}

