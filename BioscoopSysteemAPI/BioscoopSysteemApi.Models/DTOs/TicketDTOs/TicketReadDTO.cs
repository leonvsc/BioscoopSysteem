using System.ComponentModel.DataAnnotations;

namespace BioscoopSysteemAPI.DTOs.TicketDTOs
{
    public class TicketReadDTO
    {
        public int TicketId { get; set; }

        public DateTime DateTime { get; set; }

        [MaxLength(50)]
        public string MovieName { get; set; }

        public int Quantity { get; set; }

        // Navigation Property

        public int SeatId { get; set; }

        public int VisitorId { get; set; }

        public int RoomId { get; set; }

        public int PaymentId { get; set; }
    }
}
