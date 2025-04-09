using Ambev.DeveloperEvaluation.Application.Common;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.Application.ShoppingCarts.FilterCart;

public class FilterCartResult : PaginatedList<GetCart.GetCartResult>
{
    public FilterCartResult(List<GetCart.GetCartResult> items, int count, PaginatedSearchBase paginationParams) : base(items, count, paginationParams)
    {
    }

    public static async Task<FilterCartResult> CreateAsync(PaginatedSearchBase paginationParams, IQueryable<Domain.Entities.ShoppingCart> source, AutoMapper.IMapper mapper)
    {
        var count = await source.CountAsync();
        var items = await source.ApplyPagination(paginationParams).ToListAsync();
        var mappedItems = mapper.Map<List<GetCart.GetCartResult>>(items);
        return new FilterCartResult(mappedItems, count, paginationParams);
    }
}
