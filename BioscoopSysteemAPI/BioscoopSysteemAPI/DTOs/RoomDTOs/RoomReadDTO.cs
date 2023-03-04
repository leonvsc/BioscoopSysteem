namespace BioscoopSysteemAPI.DTOs.RoomDTOs
{
    public class RoomReadDTO
    {
        public int RoomId { get; set; }
        public bool InUse { get; set; }
        public int NumberOfSeatsAvailable { get; set; }
    }
}
