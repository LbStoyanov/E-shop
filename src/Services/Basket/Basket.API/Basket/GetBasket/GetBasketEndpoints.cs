

namespace Basket.API.Basket.GetBasket;

//public record GetBasketRequest(string UserName);

public record GetBasketResponse(ShoppingCart Cart);

public class GetBasketEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        throw new NotImplementedException();
    }
}

