using System.ComponentModel.DataAnnotations;

namespace BioscoopSysteemAPI.DTOs.SeatDTOs
{
    public class SeatReadDTO
    {
        // Properties
        public int SeatId { get; set; }
        public int SeatNumber { get; set; }

        public int SeatRow { get; set; }

        // Navigation Property
        public int? MovieId { get; set; }
    }
}
