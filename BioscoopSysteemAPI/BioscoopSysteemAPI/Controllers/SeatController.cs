using System.Net.Mime;
using AutoMapper;
using BioscoopSysteemAPI.DTOs.SeatDTOs;
using BioscoopSysteemAPI.Interfaces;
using BioscoopSysteemAPI.Models;
using BioscoopSysteemAPI.Services;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BioscoopSysteemAPI.Controllers
{
    [Route("api/seats")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class SeatController : ControllerBase
    {
        
        private readonly ISeatRepository _seatRepository;
        private readonly IMapper _mapper;
 

        public SeatController(ISeatRepository seatRepository, IMapper mapper )
        {
            _seatRepository = seatRepository;
            _mapper = mapper;
        }

        // GET: api/Seats
        /// <summary>
        /// Get all Seats.
        /// </summary>
        /// <response code="200">Succesfully returns a Seat object.</response>
        /// <returns>A list of Seat objects.</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SeatReadDTO>>> GetSeats()
        {
            try
            {
                var domainSeats = await _seatRepository.GetSeatsAsync();

                if (domainSeats == null)
                {
                    return NotFound();
                }

                var dtoSeats = _mapper.Map<List<SeatReadDTO>>(domainSeats);

                return Ok(dtoSeats);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        // GET: api/Seats/1
        /// <summary>
        /// Get a Seat by ID.
        /// </summary>
        /// <param name="id">Id of the Seat.</param>
        /// <returns>A Seat object.</returns>
        /// <response code="200">Succesfully returns a Seat object.</response>
        /// <response code="404">Error: The object you are looking for is not found.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<SeatReadDTO>> GetSeat(int id)
        {
            try
            {
                var domainSeat = await _seatRepository.GetSeatByIdAsync(id);
                var dtoSeat = _mapper.Map<SeatReadDTO>(domainSeat.Value);

                if (dtoSeat == null)
                {
                    return NotFound();
                }
                return Ok(dtoSeat);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        // DELETE: api/Seats/1
        /// <summary>
        /// Delete an object by Id in the database.
        /// </summary>
        /// <param name="id">Id of the object.</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<SeatDeleteDTO>> DeleteSeat(int id)
        {
            try
            {
                var seat = await _seatRepository.DeleteSeatAsync(id);

                if (seat == null)
                {
                    return NotFound();
                }
                return Ok(seat);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        /// <summary>
        /// Update a Seat.
        /// </summary>
        /// <param name="id">Id of the Seat</param>
        /// <param name="Seat">Seat object</param>
        /// <returns>Action result without content.</returns>
        /// <response code="204">Succesfully updated object.</response>
        /// <response code="404">Error: The object you are looking for is not found.</response>
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public async Task<ActionResult<Seat>> PutSeat(int id, Seat seat)
        {

            if (id != seat.SeatId)
            {
                return BadRequest();
            }

            try
            {
                var domainSeat = await _seatRepository.PutSeatAsync(id, seat);

                if (domainSeat == null)
                {
                    return NotFound();
                }
                return Ok(seat);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        // POST: api/Seats
        /// <summary>
        /// Creates a new Seat object.
        /// </summary>
        /// <param name="payment">A Seat object.</param>
        /// <returns>The new Seat object.</returns>
        /// <response code="201">Succesfully created object.</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<ActionResult<SeatCreateDTO>> PostSeat(SeatCreateDTO seatDto)
        {
            try
            {
                var domainSeat = _mapper.Map<Seat>(seatDto);

                if (domainSeat == null)
                {
                    return NoContent();
                }

                int seatId = _seatRepository.PostSeatAsync(domainSeat).Id;

                return CreatedAtAction("GetSeat", new { id = seatId }, seatDto);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        // GET: api/Seats
        /// <summary>
        /// Get empty seats for selection.
        /// </summary>
        /// <response code="200">Succesfully returns the seat objects.</response>
        /// <returns>A list of Seat objects.</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("/emptyseats")]
        public async Task<ActionResult<IEnumerable<SeatReadDTO>>> GetEmptySeatsForSelection()
        {
            try
            {
                var seat = new EmptySeatsForSelection(_seatRepository){ };

                var domainSeats = await seat.GetEmptySeatsForSelection();
                
                return Ok(domainSeats);

            /*    if (domainSeats == null)
                {
                    return NotFound();
                }*/

                

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }

        }

    }
}




