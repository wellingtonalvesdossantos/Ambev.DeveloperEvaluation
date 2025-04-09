using Ambev.DeveloperEvaluation.Application.Common;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Extensions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.Application.Users.FilterUser
{
    public class FilterUserResult : PaginatedList<GetUser.GetUserResult>
    {
        public FilterUserResult(List<GetUser.GetUserResult> items, int count, PaginatedSearchBase paginationParams) : base(items, count, paginationParams)
        {
        }

        public static async Task<FilterUserResult> CreateAsync(PaginatedSearchBase paginationParams, IQueryable<User> source, IMapper mapper)
        {
            var count = await source.CountAsync();
            var items = await source.ApplyPagination(paginationParams).ToListAsync();
            var mappedItems = mapper.Map<List<GetUser.GetUserResult>>(items);
            return new FilterUserResult(mappedItems, count, paginationParams);
        }
    }
}
