using Ambev.DeveloperEvaluation.Application.ShoppingCarts.GetCart;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.ShoppingCarts.GetCart;

public class GetCartProfile : Profile
{
    public GetCartProfile()
    {
        CreateMap<Guid, GetCartCommand>()
            .ConstructUsing(id => new GetCartCommand(id));
        CreateMap<GetCartResult, GetCartResponse>();
        CreateMap<GetCartItemResult, GetCartItemResponse>();
    }
}