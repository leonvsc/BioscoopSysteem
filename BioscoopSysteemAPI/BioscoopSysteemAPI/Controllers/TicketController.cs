using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using BioscoopSysteemAPI.Dal.Repository;
using BioscoopSysteemAPI.DTOs.PaymentDTOs;
using BioscoopSysteemAPI.DTOs.ReservationDTOs;
using BioscoopSysteemAPI.DTOs.TicketDTOs;
using BioscoopSysteemAPI.Interfaces;
using BioscoopSysteemAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BioscoopSysteemAPI.Controllers
{
    [Route("api/tickets")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class TicketController : ControllerBase
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;

        public TicketController(ITicketRepository ticketRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }

        // GET: api/tickets
        /// <summary>
        /// Get all tickets.
        /// </summary>
        /// <response code="200">Succesfully returns a list of ticket objects.</response>
        /// <returns>A list of reservation objects.</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketReadDTO>>> GetTickets()
        {
            try
            {
                var domainTickets = await _ticketRepository.GetTicketsAsync();

                if (domainTickets == null)
                {
                    return NotFound();
                }

                var dtoTickets = _mapper.Map<List<TicketReadDTO>>(domainTickets.Value);

                return Ok(dtoTickets);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        // GET: api/payments/1
        /// <summary>
        /// Get a ticket by ID.
        /// </summary>
        /// <param name="id">Id of the ticket.</param>
        /// <returns>A ticket object.</returns>
        /// <response code="200">Succesfully returns a ticket object.</response>
        /// <response code="404">Error: The object you are looking for is not found.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketReadDTO>> GetTicket(int id)
        {
            try
            {
                var domainTicket = await _ticketRepository.GetTicketByIdAsync(id);
                var dtoTicket = _mapper.Map<TicketReadDTO>(domainTicket.Value);

                if (dtoTicket == null)
                {
                    return NotFound();
                }
                return Ok(dtoTicket);
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
        public async Task<ActionResult<TicketDeleteDTO>> DeleteTicket(int id)
        {
            try
            {
                var ticket = await _ticketRepository.DeleteTicketAsync(id);

                if (ticket == null)
                {
                    return NotFound();
                }
                return Ok(ticket);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        /// <summary>
        /// Update a ticket.
        /// </summary>
        /// <param name="id">Id of the ticket</param>
        /// <param name="ticket">Ticket object</param>
        /// <returns>Action result without content.</returns>
        /// <response code="204">Succesfully updated object.</response>
        /// <response code="404">Error: The object you are looking for is not found.</response>
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public async Task<ActionResult<Ticket>> PutTicket(int id, Ticket ticket)
        {

            if (id != ticket.TicketId)
            {
                return BadRequest();
            }

            try
            {
                var domainTicket = await _ticketRepository.PutTicketAsync(id, ticket);

                if (domainTicket == null)
                {
                    return NotFound();
                }
                return Ok(ticket);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        // POST: api/reservations
        /// <summary>
        /// Creates a new ticket object.
        /// </summary>
        /// <param name="reservation">A ticket object.</param>
        /// <returns>The new ticket object.</returns>
        /// <response code="201">Succesfully created object.</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<ActionResult<TicketCreateDTO>> PostTicket(TicketCreateDTO ticketDto)
        {
            try
            {
                var domainTicket = _mapper.Map<Ticket>(ticketDto);

                if (domainTicket == null)
                {
                    return NoContent();
                }

                await _ticketRepository.PostTicketAsync(domainTicket);

                int ticketId = _ticketRepository.PostTicketAsync(domainTicket).Id;

                return CreatedAtAction("GetTicket", new { id = ticketId }, ticketDto);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
    }
}
