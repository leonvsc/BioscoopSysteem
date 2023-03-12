using BioscoopSysteemAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BioscoopSysteemAPI.Interfaces
{
    public interface IVisitorRepository
    {
        Task<ActionResult<IEnumerable<Visitor>>> GetVisitorsAsync();

        Task<ActionResult<Visitor>> GetVisitorByIdAsync(int id);

        Task<ActionResult<Visitor>> PostVisitorAsync(Visitor visitor);
        Task<ActionResult<Visitor>> PutVisitorAsync(int id, Visitor visitor);

        Task<ActionResult<Visitor>> DeleteVisitorAsync(int id);
    }
}
