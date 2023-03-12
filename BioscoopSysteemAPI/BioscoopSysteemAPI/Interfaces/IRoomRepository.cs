using BioscoopSysteemAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BioscoopSysteemAPI.Interfaces
{
    public interface IRoomRepository
    {
        Task<ActionResult<IEnumerable<Room>>> GetRoomsAsync();
        
        Task<ActionResult<Room>> GetRoomByIdAsync(int id);

        Task<ActionResult<Room>> PostRoomAsync(Room Room);

        Task<ActionResult<Room>> PutRoomAsync(int id, Room Room);

        Task<ActionResult<Room>> DeleteRoomAsync(int id);
    }
}
