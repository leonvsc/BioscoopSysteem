using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using BioscoopSysteemAPI.Dal.Repository;
using BioscoopSysteemAPI.DTOs.MovieDTOs;
using BioscoopSysteemAPI.DTOs.PaymentDTOs;
using BioscoopSysteemAPI.Interfaces;
using BioscoopSysteemAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BioscoopSysteemAPI.Controllers
{
    [Route("api/payments")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public PaymentController(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        // GET: api/payments
        /// <summary>
        /// Get all payments.
        /// </summary>
        /// <response code="200">Succesfully returns a payment object.</response>
        /// <returns>A list of payment objects.</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentReadDTO>>> GetPayments()
        {
            try
            {
                var domainPayments = await _paymentRepository.GetPaymentsAsync();

                if (domainPayments == null)
                {
                    return NotFound();
                }

                var dtoPayments = _mapper.Map<List<PaymentReadDTO>>(domainPayments.Value);

                return Ok(dtoPayments);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        // GET: api/payments/1
        /// <summary>
        /// Get a payment by ID.
        /// </summary>
        /// <param name="id">Id of the payment.</param>
        /// <returns>A payment object.</returns>
        /// <response code="200">Succesfully returns a payment object.</response>
        /// <response code="404">Error: The object you are looking for is not found.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentReadDTO>> GetPayment(int id)
        {
            try
            {
                var domainPayment = await _paymentRepository.GetPaymentByIdAsync(id);
                var dtoPayment = _mapper.Map<PaymentReadDTO>(domainPayment.Value);

                if (dtoPayment == null)
                {
                    return NotFound();
                }
                return Ok(dtoPayment);
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
        public async Task<ActionResult<PaymentDeleteDTO>> DeletePayment(int id)
        {
            try
            {
                var payment = await _paymentRepository.DeletePaymentAsync(id);

                if (payment == null)
                {
                    return NotFound();
                }
                return Ok(payment);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        /// <summary>
        /// Update a payment.
        /// </summary>
        /// <param name="id">Id of the payment</param>
        /// <param name="payment">Payment object</param>
        /// <returns>Action result without content.</returns>
        /// <response code="204">Succesfully updated object.</response>
        /// <response code="404">Error: The object you are looking for is not found.</response>
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public async Task<ActionResult<Payment>> PutPayment(int id, Payment payment)
        {

            if (id != payment.PaymentId)
            {
                return BadRequest();
            }

            try
            {
                var domainPayment = await _paymentRepository.PutPaymentAsync(id, payment);

                if (domainPayment == null)
                {
                    return NotFound();
                }
                return Ok(payment);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        // POST: api/movies
        /// <summary>
        /// Creates a new payment object.
        /// </summary>
        /// <param name="payment">A payment object.</param>
        /// <returns>The new payment object.</returns>
        /// <response code="201">Succesfully created object.</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<ActionResult<PaymentCreateDTO>> PostPayment(PaymentCreateDTO paymentDto)
        {
            try
            {
                var domainPayment = _mapper.Map<Payment>(paymentDto);

                if (domainPayment == null)
                {
                    return NoContent();
                }

                await _paymentRepository.PostPaymentAsync(domainPayment);

                int paymentId = _paymentRepository.PostPaymentAsync(domainPayment).Id;

                return CreatedAtAction("GetPayment", new { id = paymentId }, paymentDto);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
    }
}

