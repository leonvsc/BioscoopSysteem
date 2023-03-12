using BioscoopSysteemAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BioscoopSysteemAPI.Interfaces
{
    public interface ITicketRepository
    {
        Task<ActionResult<IEnumerable<Ticket>>> GetTicketsAsync();

        Task<ActionResult<Ticket>> GetTicketByIdAsync(int id);

        Task<ActionResult<Ticket>> PostTicketAsync(Ticket ticket);
        Task<ActionResult<Ticket>> PutTicketAsync(int id, Ticket ticket);

        Task<ActionResult<Ticket>> DeleteTicketAsync(int id);
    }
}
