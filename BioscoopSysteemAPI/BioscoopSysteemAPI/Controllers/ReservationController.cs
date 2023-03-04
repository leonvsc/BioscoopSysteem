using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using BioscoopSysteemAPI.Dal.Repository;
using BioscoopSysteemAPI.DTOs.PaymentDTOs;
using BioscoopSysteemAPI.DTOs.ReservationDTOs;
using BioscoopSysteemAPI.Interfaces;
using BioscoopSysteemAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BioscoopSysteemAPI.Controllers
{
    [Route("api/reservations")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public ReservationController(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        // GET: api/reservations
        /// <summary>
        /// Get all reservations.
        /// </summary>
        /// <response code="200">Succesfully returns a rservation object.</response>
        /// <returns>A list of reservation objects.</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservationReadDTO>>> GetReservation()
        {
            try
            {
                var domainReservations = await _reservationRepository.GetReservationsAsync();

                if (domainReservations == null)
                {
                    return NotFound();
                }

                var dtoReservations = _mapper.Map<List<ReservationReadDTO>>(domainReservations.Value);

                return Ok(dtoReservations);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        // GET: api/payments/1
        /// <summary>
        /// Get a reservation by ID.
        /// </summary>
        /// <param name="id">Id of the reservation.</param>
        /// <returns>A reservation object.</returns>
        /// <response code="200">Succesfully returns a reservation object.</response>
        /// <response code="404">Error: The object you are looking for is not found.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationReadDTO>> GetReservation(int id)
        {
            try
            {
                var domainReservation = await _reservationRepository.GetReservationByIdAsync(id);
                var dtoReservation = _mapper.Map<ReservationReadDTO>(domainReservation.Value);

                if (dtoReservation == null)
                {
                    return NotFound();
                }
                return Ok(dtoReservation);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        // DELETE: api/payment/1
        /// <summary>
        /// Delete an object by Id in the database.
        /// </summary>
        /// <param name="id">Id of the object.</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ReservationDeleteDTO>> DeleteReservation(int id)
        {
            try
            {
                var reservation = await _reservationRepository.DeleteReservationAsync(id);

                if (reservation == null)
                {
                    return NotFound();
                }
                return Ok(reservation);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        /// <summary>
        /// Update a reservation.
        /// </summary>
        /// <param name="id">Id of the reservation</param>
        /// <param name="reservation">Reservation object</param>
        /// <returns>Action result without content.</returns>
        /// <response code="204">Succesfully updated object.</response>
        /// <response code="404">Error: The object you are looking for is not found.</response>
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public async Task<ActionResult<Reservation>> PutReservation(int id, Reservation reservation)
        {

            if (id != reservation.ReservationId)
            {
                return BadRequest();
            }

            try
            {
                var domainReservation = await _reservationRepository.PutReservationAsync(id, reservation);

                if (domainReservation == null)
                {
                    return NotFound();
                }
                return Ok(reservation);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        // POST: api/reservations
        /// <summary>
        /// Creates a new reservation object.
        /// </summary>
        /// <param name="reservation">A payment object.</param>
        /// <returns>The new payment object.</returns>
        /// <response code="201">Succesfully created object.</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<ActionResult<ReservationCreateDTO>> PostReservation(ReservationCreateDTO reservationDto)
        {
            try
            {
                var domainReservation = _mapper.Map<Reservation>(reservationDto);

                if (domainReservation == null)
                {
                    return NoContent();
                }

                await _reservationRepository.PostReservationAsync(domainReservation);

                int reservationId = _reservationRepository.PostReservationAsync(domainReservation).Id;

                return CreatedAtAction("GetReservation", new { id = reservationId }, reservationDto);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
    }
}
