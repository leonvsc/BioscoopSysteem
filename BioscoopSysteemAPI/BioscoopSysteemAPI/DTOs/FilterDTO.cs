namespace BioscoopSysteemAPI.DTOs
{
    public class FilterDTO
    {

        public string? search { get; set; }
        public int? age { get; set; }
        public bool? threeDee { get; set; }
        public string? genre { get; set; }
        public string? specials { get; set; }
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
