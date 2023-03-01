// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using BioscoopSysteemAPI.Models;
// using BioscoopSysteemAPI.Repository;
//
// namespace BioscoopSysteemAPI.Services
// {
// 	public class ReservationService
// 	{
// 		private readonly ReservationRepository reservationRepository;
// 		
// 		public ReservationService(ReservationRepository reservationRepository)
// 		{
// 			this.reservationRepository = reservationRepository; 
// 		}
//
// 		public IsNumerable<Reservation> getReservations()
// 		{
// 			var reservation = reservationRepository.GetReservations();
// 			if (reservation == null)
// 			{
// 				return null;
// 			}
// 			return reservation;
// 		}
//
// 		public Reservation deleteReservation(int reservationId)
// 		{
// 			var reservation = reservationRepositiory.GetReservation(reservationId);
// 			if (reservation == null)
// 			{
// 				return null;
// 			}
// 			reservationRepository.DeleteReservation(reservationId);
// 			return reservation;
// 		}
//
// 		public Reservation createReservation(Reservation reservation)
// 		{ 
// 			if (reservation	!= null)
// 			{
// 				reservationB = reservationRepository.CreateReservation();
// 				return reservation;
// 			}
// 			return null;
// 		}
// 	}
// }