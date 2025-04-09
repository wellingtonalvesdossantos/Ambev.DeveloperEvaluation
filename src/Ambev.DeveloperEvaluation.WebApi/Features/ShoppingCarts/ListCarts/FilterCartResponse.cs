using Ambev.DeveloperEvaluation.Application.ShoppingCarts.FilterCart;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.ShoppingCarts.GetCart;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.FilterCart;

public class FilterCartResponse : PaginatedResponse<GetCartResponse>
{
    public static FilterCartResponse Create(FilterCartResult result, IMapper mapper)
    {
        var data = mapper.Map<List<GetCartResponse>>(result);
        return new()
        {
            CurrentPage = result.CurrentPage,
            TotalPages = result.TotalPages,
            TotalCount = result.TotalCount,
            Data = data,
            Success = true,
            Message = "Users retrieved successfully",
        };
    }
}