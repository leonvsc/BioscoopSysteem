using System;
using BioscoopSysteemAPI.Interfaces;
using BioscoopSysteemAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BioscoopSysteemAPI.Dal.Repository
{
    public class SeatRepository : ISeatRepository
    {
        private readonly CinemaDbContext _cinemaDbContext;


        public SeatRepository(CinemaDbContext cinemaDbContext)
        {
            this._cinemaDbContext = cinemaDbContext;
        }

        public async Task<ActionResult<IEnumerable<Seat>>> GetSeatsAsync()
        {
            var seats = await _cinemaDbContext.Seats.ToListAsync();
            return seats;
        }

        public async Task<ActionResult<Seat>> GetSeatByIdAsync(int id)
        {
            var seat = await _cinemaDbContext.Seats.FindAsync(id);
            return seat;
        }
   
        public async Task<ActionResult<Seat>> PostSeatAsync(Seat seat) 
        {
            _cinemaDbContext.Seats.Add(seat);
            await _cinemaDbContext.SaveChangesAsync();

            return seat;
        }

        public async Task<ActionResult<Seat>> DeleteSeatAsync(int id)
        {
            var seat = await _cinemaDbContext.Seats.FindAsync(id);

            _cinemaDbContext.Seats.Remove(seat);
            await _cinemaDbContext.SaveChangesAsync();

            return seat;
        }

        public async Task<ActionResult<Seat>> PutSeatAsync(int id, Seat seat)
        {

            var domainSeat = await _cinemaDbContext.Seats.FindAsync(id);
            
            if (domainSeat == null)
            {
                return null;
            }

            domainSeat.SeatId = seat.SeatId;
            domainSeat.SeatNumber = seat.SeatNumber;
            domainSeat.SeatRow = seat.SeatRow;
            domainSeat.MovieId = seat.MovieId;

            await _cinemaDbContext.SaveChangesAsync();

            return domainSeat;
        }
    }
}

