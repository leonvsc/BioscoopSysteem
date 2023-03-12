namespace BioscoopSysteemAPI.DTOs.RoomDTOs
{
    public class RoomDeleteDTO
    {
        public int RoomId { get; set; }
        public bool InUse { get; set; }
        public int NumberOfSeatsAvailable { get; set; }
    }
}
