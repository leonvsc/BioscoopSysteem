namespace BioscoopSysteemWeb.Service;

public class GetTicketInfoService
{
    private int _ticketAmount;
    private int _popcornAmount;
    private double _totalPrice;
    private int _movieId;

    public int GetMovieId()
    {
        return _movieId;
    }

    public void SetMovieId(int movieId)
    {
        _movieId = movieId;
    }
    
    public int GetTicketAmount()
    {
        return _ticketAmount;
    }

    public void SetTicketAmount(int ticketAmount)
    {
        _ticketAmount = ticketAmount;
    }
    
    public int GetPopcornAmount()
    {
        return _popcornAmount;
    }

    public void SetPopcornAmount(int popcornAmount)
    {
        _popcornAmount = popcornAmount;
    }
    
    public double GetTotalPrice()
    {
        return _totalPrice;
    }

    public void SetTotalPrice(double totalPrice)
    {
        _totalPrice = totalPrice;
    }
}