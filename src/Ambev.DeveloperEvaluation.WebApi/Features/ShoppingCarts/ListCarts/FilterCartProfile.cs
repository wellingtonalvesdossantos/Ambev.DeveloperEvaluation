using Ambev.DeveloperEvaluation.Application.ShoppingCarts.FilterCart;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.FilterCart;

public class FilterCartProfile : Profile
{
    public FilterCartProfile()
    {
        CreateMap<FilterCartRequest, FilterCartCommand>();
    }
}