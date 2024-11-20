namespace Basket.API.Exceptions;


public class BasketNotFoundException : NotFoundException
{

    public BasketNotFoundException( string userName) : base("basket", userName)
    {
        
    }
}

