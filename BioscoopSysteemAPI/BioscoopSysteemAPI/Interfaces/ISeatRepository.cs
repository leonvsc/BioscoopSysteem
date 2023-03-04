using BioscoopSysteemAPI.Models;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BioscoopSysteemAPI.Interfaces
{
    public interface ISeatRepository
    {
        Task<ActionResult<IEnumerable<Seat>>> GetSeatsAsync();
        
        Task<ActionResult<Seat>> GetSeatByIdAsync(int id);

        Task<ActionResult<Seat>> PostSeatAsync(Seat seat);

        Task<ActionResult<Seat>> PutSeatAsync(int id, Seat seat);

        Task<ActionResult<Seat>> DeleteSeatAsync(int id);
    }
}
