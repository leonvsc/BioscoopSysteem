namespace BioscoopSysteemAPI.Models;

public class TicketModel
{
    public string Id { get; set; }
    public string Price { get; set; }
    public string EventName { get; set; }
    public DateTime EventDate { get; set; }
    public string TicketType { get; set; }
}