namespace BioscoopSysteemAPI.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public bool InUse { get; set; }
        public int NumberOfSeatsAvailable { get; set; }
    }
}
