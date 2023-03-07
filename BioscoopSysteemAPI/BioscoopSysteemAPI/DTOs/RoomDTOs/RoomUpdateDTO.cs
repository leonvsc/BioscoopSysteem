namespace BioscoopSysteemAPI.DTOs.RoomDTOs
{
    public class RoomUpdateDTO
    {
        public int RoomId { get; set; }
        public bool InUse { get; set; }
        public int NumberOfSeatsAvailable { get; set; }
    }
}
