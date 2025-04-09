using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.ShoppingCarts.GetCart;

public class GetCartProfile : AutoMapper.Profile
{
    public GetCartProfile()
    {
        CreateMap<ShoppingCart, GetCartResult>();
        CreateMap<ShoppingCartItem, GetCartItemResult>();
    }
}
