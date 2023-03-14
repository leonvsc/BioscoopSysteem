using System;
using BioscoopSysteemAPI.Interfaces;
using BioscoopSysteemAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BioscoopSysteemAPI.Dal.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly CinemaDbContext _cinemaDbContext;

        public TicketRepository(CinemaDbContext cinemaDbContext)
        {
            this._cinemaDbContext = cinemaDbContext;
        }

        public async Task<ActionResult<IEnumerable<Ticket>>> GetTicketsAsync()
        {
            var tickets = await _cinemaDbContext.Tickets.ToListAsync();

            return tickets;
        }

        public async Task<ActionResult<Ticket>> GetTicketByIdAsync(int id)
        {
            var ticket = await _cinemaDbContext.Tickets.FindAsync(id);

            return ticket;
        }

        public async Task<ActionResult<Ticket>> PostTicketAsync(Ticket ticket)
        {
            _cinemaDbContext.Tickets.Add(ticket);
            await _cinemaDbContext.SaveChangesAsync();

            return ticket;
        }

        public async Task<ActionResult<Ticket>> DeleteTicketAsync(int id)
        {
            var ticket = await _cinemaDbContext.Tickets.FindAsync(id);

            _cinemaDbContext.Tickets.Remove(ticket);
            await _cinemaDbContext.SaveChangesAsync();

            return ticket;
        }

        public async Task<ActionResult<Ticket>> PutTicketAsync(int id, Ticket ticket)
        {
            var domainTicket = await _cinemaDbContext.Tickets.FindAsync(id);

            if (domainTicket == null)
            {
                return null;
            }

            domainTicket.TicketId = ticket.TicketId;
            domainTicket.DateTime = ticket.DateTime;
            domainTicket.MovieName = ticket.MovieName;
            domainTicket.Quantity = ticket.Quantity;
            domainTicket.SeatId = ticket.SeatId;
            domainTicket.VisitorId = ticket.VisitorId;
            domainTicket.RoomId = ticket.RoomId;
            domainTicket.PaymentId = ticket.PaymentId;
            
            await _cinemaDbContext.SaveChangesAsync();

            return domainTicket;
        }
    }
}

