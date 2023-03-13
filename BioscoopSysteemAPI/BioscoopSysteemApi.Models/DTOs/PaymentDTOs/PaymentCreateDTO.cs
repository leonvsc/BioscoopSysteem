using System.ComponentModel.DataAnnotations;

namespace BioscoopSysteemAPI.DTOs.PaymentDTOs
{
    public class PaymentCreateDTO
    {
        // Properties
        public int PaymentId { get; set; }
        public string MollieId { get; set; }

        public DateTime PaidAt { get; set; }

        public int Amount { get; set; }
        
        [MaxLength(50)]
        public string PaymentMethod { get; set; }
        
        public string PaymentStatus { get; set; }
        public int ReservationId { get; set; }
    }
}
