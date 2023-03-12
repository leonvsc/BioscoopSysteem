using System.ComponentModel.DataAnnotations;

namespace BioscoopSysteemAPI.DTOs.ReservationDTOs
{
    public class ReservationCreateDTO
    {
        // Properties
        public int ReservationId { get; set; }

        public DateTime DateTime { get; set; }

        [MaxLength(50)]
        public string Location{ get; set;}
        
        public int TicketAmount { get; set; }
        
        public string Age { get; set; }
        public string Arrangementen { get; set; }
        public double TotalPrice { get; set; }
        public bool IsStudent { get; set; }

        // Navigation Property
        
        public int PaymentId { get; set; }
        public int SeatId { get; set; }

        public int MovieId { get; set; }

        public int VisitorId { get; set; }
    }
}
