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
    public class ReservationController : ControllerBase
    {
        private readonly ReservationRepository reservationRepository;

        public ReservationController(ReservationRepository reservationRepository)
        {
            this.reservationRepository = reservationRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservations()
        {
            try
            {
                var reservations = await this.reservationRepository.GetReservations();

                if (reservations == null)
                {
                    return NotFound();
                }
                return Ok(reservations);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Reservation>> RemoveReservation(int id)
        {
            try
            {
                var reservation = await this.reservationRepository.DeleteReservation(id);

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

        [HttpPost]
        public async Task<ActionResult<Reservation>> MakeReservation([FromBody] Reservation reservation)
        {
            try
            {
                var aReservation = await this.reservationRepository.CreateReservation(reservation);

                if (aReservation == null)
                {
                    return NoContent();
                }
                return Ok(aReservation);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
    }
}
