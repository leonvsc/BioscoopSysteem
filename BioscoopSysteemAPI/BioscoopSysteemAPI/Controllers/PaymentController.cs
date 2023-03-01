using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BioscoopSysteemAPI.Dal.Repository;
using BioscoopSysteemAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BioscoopSysteemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentRepository paymentRepository;

        public PaymentController(PaymentRepository paymentRepository)
        {
            this.paymentRepository = paymentRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payment>>> GetPayments()
        {
            try
            {
                var payments = await this.paymentRepository.GetPayments();

                if (payments == null)
                {
                    return NotFound();
                }
                return Ok(payments);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
    }
}

