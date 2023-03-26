namespace BioscoopSysteemAPI.DTOs.RoomDTOs
{
    public class RoomCreateDTO
    {
        public int RoomId { get; set; }
        public bool InUse { get; set; }
        public int NumberOfSeatsAvailable { get; set; }
    }
}
