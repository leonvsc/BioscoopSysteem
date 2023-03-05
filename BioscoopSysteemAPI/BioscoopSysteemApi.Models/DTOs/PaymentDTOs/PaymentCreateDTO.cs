using System.ComponentModel.DataAnnotations;

namespace BioscoopSysteemAPI.DTOs.PaymentDTOs
{
    public class PaymentCreateDTO
    {

        public DateTime DateTime { get; set; }

        public int Amount { get; set; }

        [MaxLength(50)]
        public string PaymentMethod { get; set; }

        // Navigation Property

        public int ReservationId { get; set; }
    }
}
