/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BioscoopSysteemAPI.Models;
using BioscoopSysteemAPI.Dal.Repository;

namespace BioscoopSysteemAPI.Services
{
	public class ReservationService
	{
		private readonly ReservationRepository reservationRepository;

		public ReservationService(ReservationRepository reservationRepository)
		{
			this.reservationRepository = reservationRepository;
		}

		public async Task<IEnumerable<Reservation>> GetReservations()
		{
			var reservation = await reservationRepository.GetReservations();
			if (reservation == null)
			{
				return null;
			}
			return reservation;
		}

		public async Task<Reservation> DeleteReservation(int id)
		{
			var reservation = await reservationRepository.GetReservationById(id);
			if (reservation == null)
			{
				return null;
			}
			reservationRepository.DeleteReservation(id);
			return reservation;
		}

		public async Task<Reservation> createReservation(Reservation reservationInput)
		{
			if (reservationInput != null)
			{
				var reservationB = await reservationRepository.CreateReservation(reservationInput);
				return reservationInput;
			}
			return null;
		}
	}
}*/