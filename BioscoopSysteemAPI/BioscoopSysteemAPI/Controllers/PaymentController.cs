using System.Drawing;
using System.Globalization;
using System.Net.Mime;
using AutoMapper;
using BioscoopSysteemAPI.DTOs.PaymentDTOs;
using BioscoopSysteemAPI.Interfaces;
using BioscoopSysteemAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Mollie.Api.Client;
using Mollie.Api.Client.Abstract;
using Mollie.Api.Models;
using Mollie.Api.Models.Payment.Request;
using Mollie.Api.Models.Payment.Response;
using Newtonsoft.Json;
using QRCoder;

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
        
        private IPaymentClient paymentClient = new PaymentClient("test_KKMaBKv5ngVQdxAUx6jpbe9Js5kGg2");

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

        [HttpPost("payWithMollie")]
        public async Task<IActionResult> PayWithMollie(PaymentRequestModel model)
        {
            PaymentRequest paymentRequest = new PaymentRequest() {
                Amount = new Amount(Currency.EUR, model.Amount),
                Description = model.ReservertionId,
                RedirectUrl = "http://localhost:5047/ticket?resid={model.ReservertionId}",
                WebhookUrl = "https://e2e7-195-230-110-6.eu.ngrok.io/api/payments/mollieWebhook"
            };

            PaymentResponse paymentResponse = await paymentClient.CreatePaymentAsync(paymentRequest);

            return Ok(paymentResponse.Links.Checkout.Href);
        }

        [HttpPost("mollieWebhook")]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<IActionResult> mollieWebhook()
        {
            string mollieId = Request.Form["id"];

            PaymentResponse payment = await paymentClient.GetPaymentAsync(mollieId);

            if (payment != null && payment.Status == "paid")
            {
                // Payment is successful
                DateTime paidAt = payment.PaidAt.HasValue ? payment.PaidAt.Value : default(DateTime);
                var newPayment = new Payment
                {
                    MollieId = mollieId,
                    PaidAt = paidAt,
                    Amount = payment.Amount,
                    PaymentMethod = payment.Method,
                    PaymentStatus = payment.Status,
                    ReservationId = int.Parse(payment.Description)
                };

                await _paymentRepository.PostPaymentAsync(newPayment);
            }

            return Ok();
        }

        // Kan waarschijnlijk verwijderd worden.
        private void GenerateTickets(PaymentResponse payment)
        {
            // Generate a unique ticket ID
            string ticketId = Guid.NewGuid().ToString();

            // Create a ticket object with the ticket details
            TicketModel ticket = new TicketModel()
            {
                Id = ticketId,
                Price = payment.Amount.Value,
                EventName = "Example Event",
                EventDate = DateTime.Now.AddDays(7),
                TicketType = "VIP"
            };

            // Generate a QR code with the ticket ID
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(ticketId, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            // Convert the QR code to a bitmap image
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            // TODO: save the ticket with the QR code image to a file or database
        }

    }
}