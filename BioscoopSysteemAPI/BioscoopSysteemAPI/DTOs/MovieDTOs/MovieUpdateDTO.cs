using System.ComponentModel.DataAnnotations;

namespace BioscoopSysteemAPI.DTOs.MovieDTOs
{
    public class MovieUpdateDTO
    {
        public int MovieId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }
        public int Price { get; set; }
        public byte AllowedAge { get; set; }

        [MaxLength(255)]
        public string? ImageUrl { get; set; }

        // Navigation Property
        public int RoomId { get; set; }
    }
}
