﻿using System.ComponentModel.DataAnnotations;

namespace BioscoopSysteemAPI.DTOs.SeatDTOs
{
    public class SeatCreateDTO
    {
        // Properties
        public int SeatNumber { get; set; }

        public int SeatRow { get; set; }

        // Navigation Property
        public int? MovieId { get; set; }
    }
}
