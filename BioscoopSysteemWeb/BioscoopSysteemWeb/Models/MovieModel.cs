using System.ComponentModel.DataAnnotations;

public class MovieModel
{ 
        public int MovieId { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }
        public bool Add3DMovie { get; set; }

        public string Description { get; set; }
        public int Price { get; set; }
        public byte AllowedAge { get; set; }

        public string? ImageUrl { get; set; }
        
        public string Language { get; set; }
        public bool Subtitles { get; set; }
        public string Genre { get; set; }
        public string Specials { get; set; }

}