namespace BioscoopSysteemWeb.Models;

public class ReservationModel
{
    public int TicketCount { get; set; }
    public int PopcornAmount { get; set; }
    public bool IsStudent { get; set; }
    public bool WantsPopcorn { get; set; }
    public bool Is3D { get; set; }
    public string Age { get; set; }
    
    public double TotalPrice 
    { 
        get 
        {
            double price = 0;
            int movieTime = 130;
            DayOfWeek dag = DayOfWeek.Monday;

            if (movieTime > 120)
            {
                price = 9;
            }

            if (dag is DayOfWeek.Monday or DayOfWeek.Tuesday or DayOfWeek.Wednesday or DayOfWeek.Thursday)
            {
                if (IsStudent || Age == "t/m 11" || Age == "65 +")
                {
                    price = price - 1.5;
                }
            }

            if (WantsPopcorn)
            {
                price = price + 4.5;
            }
            
            if (Is3D)
            {
                price = price + 3.5;
            }

            double totalprice = price * TicketCount;

            return totalprice;
        }
    }
}
