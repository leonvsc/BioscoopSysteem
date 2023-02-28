using System;
using BioscoopSysteemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BioscoopSysteemAPI.Dal.Repository
{
    public class ReservationRepository
    {
        private readonly CinemaDbContext cinemaDbContext;

        public ReservationRepository(CinemaDbContext cinemaDbContext)
        {
            this.cinemaDbContext = cinemaDbContext;
        }

        public async Task<IEnumerable<Reservation>> GetReservations()
        {
            var reservations = await cinemaDbContext.Reservations.ToListAsync();
            return reservations;
        }

        public async Task<Reservation> DeleteReservation(int id)
        {
            var reservation = await cinemaDbContext.Reservations.FindAsync(id);

            if (reservation != null)
            {
                cinemaDbContext.Reservations.Remove(reservation);
                await cinemaDbContext.SaveChangesAsync();
            }
            return reservation;
        }

        public async Task<Reservation> MakeReservation(Reservation aReservation)
        {
            var reservation = await (from Reservation in cinemaDbContext.Reservations
                                     select new Reservation
                                     {
                                         ReservationId = aReservation.ReservationId,
                                         DateTime = aReservation.DateTime,
                                         Location = aReservation.Location,
                                         SeatId = aReservation.SeatId,
                                         MovieId = aReservation.MovieId,
                                         VisitorId = aReservation.VisitorId
                                     }).SingleOrDefaultAsync();
            if (reservation != null)
            {
                var result = await cinemaDbContext.Reservations.AddAsync(reservation);
                await cinemaDbContext.SaveChangesAsync();
                return result.Entity;
            }
            return null;
        }
    }
}

