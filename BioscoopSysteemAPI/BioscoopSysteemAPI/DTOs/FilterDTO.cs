namespace BioscoopSysteemAPI.DTOs
{
    public class FilterDTO
    {

        public String? search { get; set; }
        public int? age { get; set; }
        public bool? threeDee { get; set; }
        public Genre? genre { get; set; }
        public Specials? specials { get; set; }
        public string? language { get; set; }
        public bool? subtitles { get; set; }

    }

    public enum Specials
    {
        LadiesNight,
        HorrorNight,
        Marathon,
    }

}
