﻿using System.ComponentModel.DataAnnotations;

namespace BioscoopSysteemAPI.DTOs.ReservationDTOs
{
    public class ReservationDeleteDTO
    {
        // Properties
        public int ReservationId { get; set; }

        public DateTime DateTime { get; set; }

        [MaxLength(50)]
        public string Location{ get; set;}
        
        public int TicketAmount { get; set; }
        
        public string Age { get; set; }
        public double TotalPrice { get; set; }
        public bool IsStudent { get; set; }
        public bool WantsPopcorn { get; set; }
        public bool WantsVIP { get; set; }
        public bool WantsKinderfeestje { get; set; }

        // Navigation Property
        
        public int SeatId { get; set; }

        public int MovieId { get; set; }

        public int VisitorId { get; set; }
    }
}
