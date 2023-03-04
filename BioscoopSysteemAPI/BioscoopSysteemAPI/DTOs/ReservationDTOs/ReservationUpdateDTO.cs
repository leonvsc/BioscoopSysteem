using System.ComponentModel.DataAnnotations;

namespace BioscoopSysteemAPI.DTOs.ReservationDTOs
{
    public class ReservationUpdateDTO
    {
        // Properties
        public int ReservationId { get; set; }

        public DateTime DateTime { get; set; }

        [MaxLength(50)]
        public string Location { get; set; }

        // Navigation Property
        public int SeatId { get; set; }

        public int MovieId { get; set; }

        public int VisitorId { get; set; }
    }
}
