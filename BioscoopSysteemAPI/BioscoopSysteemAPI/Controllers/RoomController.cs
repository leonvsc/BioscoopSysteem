using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using BioscoopSysteemAPI.Dal.Repository;
using BioscoopSysteemAPI.DTOs.RoomDTOs;
using BioscoopSysteemAPI.Interfaces;
using BioscoopSysteemAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BioscoopSysteemAPI.Controllers
{
    [Route("api/rooms")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class RoomController : ControllerBase
    {
        
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public RoomController(IRoomRepository roomRepository, IMapper mapper )
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        // GET: api/Rooms
        /// <summary>
        /// Get all Rooms.
        /// </summary>
        /// <response code="200">Succesfully returns a Room object.</response>
        /// <returns>A list of Room objects.</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomReadDTO>>> GetRooms()
        {
            try
            {
                var domainRooms = await _roomRepository.GetRoomsAsync();

                if (domainRooms == null)
                {
                    return NotFound();
                }

                var dtoRooms = _mapper.Map<List<RoomReadDTO>>(domainRooms.Value);

                return Ok(dtoRooms);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        // GET: api/Rooms/1
        /// <summary>
        /// Get a Room by ID.
        /// </summary>
        /// <param name="id">Id of the Room.</param>
        /// <returns>A Room object.</returns>
        /// <response code="200">Succesfully returns a Room object.</response>
        /// <response code="404">Error: The object you are looking for is not found.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomReadDTO>> GetRoom(int id)
        {
            try
            {
                var domainRoom = await _roomRepository.GetRoomByIdAsync(id);
                var dtoRoom = _mapper.Map<RoomReadDTO>(domainRoom.Value);

                if (dtoRoom == null)
                {
                    return NotFound();
                }
                return Ok(dtoRoom);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        // DELETE: api/Rooms/1
        /// <summary>
        /// Delete an object by Id in the database.
        /// </summary>
        /// <param name="id">Id of the object.</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<RoomDeleteDTO>> DeleteRoom(int id)
        {
            try
            {
                var Room = await _roomRepository.DeleteRoomAsync(id);

                if (Room == null)
                {
                    return NotFound();
                }
                return Ok(Room);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        /// <summary>
        /// Update a Room.
        /// </summary>
        /// <param name="id">Id of the Room</param>
        /// <param name="Room">Room object</param>
        /// <returns>Action result without content.</returns>
        /// <response code="204">Succesfully updated object.</response>
        /// <response code="404">Error: The object you are looking for is not found.</response>
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public async Task<ActionResult<Room>> PutRoom(int id, Room Room)
        {

            if (id != Room.RoomId)
            {
                return BadRequest();
            }

            try
            {
                var domainRoom = await _roomRepository.PutRoomAsync(id, Room);

                if (domainRoom == null)
                {
                    return NotFound();
                }
                return Ok(Room);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        // POST: api/Rooms
        /// <summary>
        /// Creates a new Room object.
        /// </summary>
        /// <param name="payment">A Room object.</param>
        /// <returns>The new Room object.</returns>
        /// <response code="201">Succesfully created object.</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<ActionResult<RoomCreateDTO>> PostRoom(RoomCreateDTO roomDto)
        {
            try
            {
                var domainRoom = _mapper.Map<Room>(roomDto);

                if (domainRoom == null)
                {
                    return NoContent();
                }

                int roomId = _roomRepository.PostRoomAsync(domainRoom).Id;

                return CreatedAtAction("GetRoom", new { id = roomId }, roomDto);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

    }
}




