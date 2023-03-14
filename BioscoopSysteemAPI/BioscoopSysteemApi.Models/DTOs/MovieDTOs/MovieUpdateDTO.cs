using System.ComponentModel.DataAnnotations;

namespace BioscoopSysteemAPI.DTOs.MovieDTOs
{
    public class MovieUpdateDTO
    {
        public int MovieId { get; set; }

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
        public string? genre { get; set; }
        public string? specials { get; set; }
        public string? language { get; set; }
        public bool subtitles { get; set; }
    }
}
