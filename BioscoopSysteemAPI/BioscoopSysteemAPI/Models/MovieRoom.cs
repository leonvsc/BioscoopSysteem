namespace BioscoopSysteemAPI.Models
{
    public class MovieRoom
    {
        // Properties of model
        public int MovieId { get; set; }

        // Navigation property
        public Movie Movie { get; set; }

        public int RoomId { get; set; }

        // Navigation property
        public Room Room { get; set; }
    }
}
