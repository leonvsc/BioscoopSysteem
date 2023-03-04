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

        var domainReservation = _cinemaDbContext.Reservations.Find(id);

        await _cinemaDbContext.SaveChangesAsync();

        return domainReservation;
    }

}

