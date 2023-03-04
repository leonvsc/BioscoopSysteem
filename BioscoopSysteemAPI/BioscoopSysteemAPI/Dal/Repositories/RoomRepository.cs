using System;
using BioscoopSysteemAPI.Interfaces;
using BioscoopSysteemAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BioscoopSysteemAPI.Dal.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly CinemaDbContext _cinemaDbContext;


        public RoomRepository(CinemaDbContext cinemaDbContext)
        {
            this._cinemaDbContext = cinemaDbContext;
        }

        public async Task<ActionResult<IEnumerable<Room>>> GetRoomsAsync()
        {
            var rooms = await _cinemaDbContext.Rooms.ToListAsync();
            return rooms;
        }

        public async Task<ActionResult<Room>> GetRoomByIdAsync(int id)
        {
            var room = await _cinemaDbContext.Rooms.FindAsync(id);
            return room;
        }
   
        public async Task<ActionResult<Room>> PostRoomAsync(Room room) 
        {
            _cinemaDbContext.Rooms.Add(room);
            await _cinemaDbContext.SaveChangesAsync();

            return room;
        }

        public async Task<ActionResult<Room>> DeleteRoomAsync(int id)
        {
            var room = await _cinemaDbContext.Rooms.FindAsync(id);

            _cinemaDbContext.Rooms.Remove(room);
            await _cinemaDbContext.SaveChangesAsync();

            return room;
        }

        public async Task<ActionResult<Room>> PutRoomAsync(int id, Room room)
        {

            var domainRoom = _cinemaDbContext.Rooms.Find(id);

            await _cinemaDbContext.SaveChangesAsync();

            return domainRoom;
        }
    }
}

