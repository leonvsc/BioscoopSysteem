﻿using System.ComponentModel.DataAnnotations;

namespace BioscoopSysteemAPI.DTOs.MovieDTOs
{
    public class MovieCreateDTO
    {
        [MaxLength(50)]
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public bool Add3DMovie { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }
        public int Price { get; set; }
        public byte AllowedAge { get; set; }

        [MaxLength(255)]
        public string? ImageUrl { get; set; }

    }
}
