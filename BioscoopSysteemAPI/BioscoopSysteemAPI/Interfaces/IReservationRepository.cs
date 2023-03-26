using BioscoopSysteemAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BioscoopSysteemAPI.Interfaces
{
    public interface IReservationRepository
    {
        Task<ActionResult<IEnumerable<Reservation>>> GetReservationsAsync();

        Task<ActionResult<Reservation>> GetReservationByIdAsync(int id);

        Task<ActionResult<Reservation>> PostReservationAsync(Reservation reservation);
        Task<ActionResult<Reservation>> PutReservationAsync(int id, Reservation reservation);

        Task<ActionResult<Reservation>> DeleteReservationAsync(int id);
        //Task<int> PostReservationAsync(int reservationId);
    }
}
