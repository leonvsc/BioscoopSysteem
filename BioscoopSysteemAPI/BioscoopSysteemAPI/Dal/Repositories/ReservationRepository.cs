using System;
using BioscoopSysteemAPI.Interfaces;
using BioscoopSysteemAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BioscoopSysteemAPI.Dal.Repository;

public class ReservationRepository : IReservationRepository
{
    private readonly CinemaDbContext _cinemaDbContext;

    public ReservationRepository(CinemaDbContext cinemaDbContext)
    {
        this._cinemaDbContext = cinemaDbContext;
    }

    public async Task<ActionResult<IEnumerable<Reservation>>> GetReservationsAsync()
    {
        var reservations = await _cinemaDbContext.Reservations.ToListAsync();

        return reservations;
    }

    public async Task<ActionResult<Reservation>> GetReservationByIdAsync(int id)
    {
        var reservation = await _cinemaDbContext.Reservations.FindAsync(id);

        return reservation;
    }

    public async Task<ActionResult<Reservation>> PostReservationAsync(Reservation reservation)
    {
        _cinemaDbContext.Reservations.Add(reservation);
        await _cinemaDbContext.SaveChangesAsync();

        return reservation;
    }

    public async Task<ActionResult<Reservation>> DeleteReservationAsync(int id)
    {
        var reservation = await _cinemaDbContext.Reservations.FindAsync(id);

        _cinemaDbContext.Reservations.Remove(reservation);
        await _cinemaDbContext.SaveChangesAsync();

        return reservation;
    }

    public async Task<ActionResult<Reservation>> PutReservationAsync(int id, Reservation reservation)
    {

        var domainReservation = await _cinemaDbContext.Reservations.FindAsync(id);
        
        if (domainReservation == null)
        {
            return null;
        }

        domainReservation.ReservationId = reservation.ReservationId;
        domainReservation.DateTime = reservation.DateTime;
        domainReservation.Location = reservation.Location;
        domainReservation.SeatId = reservation.SeatId;
        domainReservation.MovieId = reservation.MovieId;
        domainReservation.VisitorId = reservation.VisitorId;

        // TODO: Uncomment after merge BIOS-107
        // domainReservation.TicketAmount = reservation.TickerAmount;
        // domainReservation.Age = reservation.Age;
        // domainReservation.TotalPrice = reservation.TotalPrice;
        // domainReservation.IsStudent = reservation.IsStudent;
        // domainReservation.WantsPopcorn = reservation.WantsPopcorn;
        // domainReservation.WantsVIP = reservation.WantsVIP;
        // domainReservation.WantsKinderfeestje = reservation.WantsKinderfeestje;

        await _cinemaDbContext.SaveChangesAsync();

        return domainReservation;
    }

}

