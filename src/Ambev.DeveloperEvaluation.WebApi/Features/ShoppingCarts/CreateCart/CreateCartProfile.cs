using Ambev.DeveloperEvaluation.Application.ShoppingCarts.CreateCart;

namespace Ambev.DeveloperEvaluation.WebApi.Features.ShoppingCarts.CreateCart;

public class CreateCartProfile : AutoMapper.Profile
{
    public CreateCartProfile()
    {
        CreateMap<CreateCartRequest, CreateCartCommand>();
        CreateMap<CreateCartItemRequest, CreateCartItemCommand>();
        CreateMap<CreateCartResult, CreateCartResponse>();
        CreateMap<CreateCartItemResult, CreateCartItemResponse>();
    }
}