using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using BioscoopSysteemAPI.Dal.Repository;
using BioscoopSysteemAPI.DTOs.ReservationDTOs;
using BioscoopSysteemAPI.DTOs.VisitorDTOs;
using BioscoopSysteemAPI.Interfaces;
using BioscoopSysteemAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BioscoopSysteemAPI.Controllers
{
    [Route("api/visitors")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class VisitorController : ControllerBase
    {
        private readonly IVisitorRepository _visitorRepository;
        private readonly IMapper _mapper;

        public VisitorController(IVisitorRepository visitorRepository, IMapper mapper)
        {
            _visitorRepository = visitorRepository;
            _mapper = mapper;
        }

        // GET: api/visitors
        /// <summary>
        /// Get all visitors.
        /// </summary>
        /// <response code="200">Succesfully returns a list of visitors object.</response>
        /// <returns>A list of visitors objects.</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VisitorReadDTO>>> GetVisitors()
        {
            try
            {
                var domainVisitors = await _visitorRepository.GetVisitorsAsync();

                if (domainVisitors == null)
                {
                    return NotFound();
                }

                var dtoVisitors = _mapper.Map<List<VisitorReadDTO>>(domainVisitors.Value);

                return Ok(dtoVisitors);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        // GET: api/payments/1
        /// <summary>
        /// Get a visitor by ID.
        /// </summary>
        /// <param name="id">Id of the visitor.</param>
        /// <returns>A visitor object.</returns>
        /// <response code="200">Succesfully returns a visitor object.</response>
        /// <response code="404">Error: The object you are looking for is not found.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<VisitorReadDTO>> GetVisitor(int id)
        {
            try
            {
                var domainVisitor = await _visitorRepository.GetVisitorByIdAsync(id);
                var dtoVisitor = _mapper.Map<VisitorReadDTO>(domainVisitor.Value);

                if (dtoVisitor == null)
                {
                    return NotFound();
                }
                return Ok(dtoVisitor);
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
        public async Task<ActionResult<VisitorDeleteDTO>> DeleteVisitor(int id)
        {
            try
            {
                var visitor = await _visitorRepository.DeleteVisitorAsync(id);

                if (visitor == null)
                {
                    return NotFound();
                }
                return Ok(visitor);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        /// <summary>
        /// Update a visitor.
        /// </summary>
        /// <param name="id">Id of the visitor</param>
        /// <param name="visitor">Visitor object</param>
        /// <returns>Action result without content.</returns>
        /// <response code="204">Succesfully updated object.</response>
        /// <response code="404">Error: The object you are looking for is not found.</response>
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public async Task<ActionResult<Visitor>> PutVisitor(int id, Visitor visitor)
        {

            if (id != visitor.VisitorId)
            {
                return BadRequest();
            }

            try
            {
                var domainVisitor = await _visitorRepository.PutVisitorAsync(id, visitor);

                if (domainVisitor == null)
                {
                    return NotFound();
                }
                return Ok(visitor);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        // POST: api/reservations
        /// <summary>
        /// Creates a new visitor object.
        /// </summary>
        /// <param name="visitor">A visitor object.</param>
        /// <returns>The new visitor object.</returns>
        /// <response code="201">Succesfully created object.</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<ActionResult<VisitorCreateDTO>> PostVisitor(VisitorCreateDTO visitorDto)
        {
            try
            {
                var domainVisitor = _mapper.Map<Visitor>(visitorDto);

                if (domainVisitor == null)
                {
                    return NoContent();
                }

                await _visitorRepository.PostVisitorAsync(domainVisitor);

                int visitorId = _visitorRepository.PostVisitorAsync(domainVisitor).Id;

                return CreatedAtAction("GetVisitor", new { id = visitorId }, visitorDto);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
    }
}
