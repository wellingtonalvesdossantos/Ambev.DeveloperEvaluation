using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.Application.Common;

public class  PaginatedList<T> : List<T>
{
    public int CurrentPage { get; private set; }
    public int TotalPages { get; private set; }
    public int PageSize { get; private set; }
    public int TotalCount { get; private set; }

    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;

    public PaginatedList(List<T> items, int count, PaginatedSearchBase paginationParams)
    {
        TotalCount = count;
        PageSize = paginationParams.PageSize.GetValueOrDefault(paginationParams.DefaultPageSize);
        CurrentPage = paginationParams.CurrentPage.GetValueOrDefault(1);
        TotalPages = (int)Math.Ceiling(count / (double)PageSize);

        AddRange(items);
    }

    public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, PaginatedSearchBase paginationParams)
    {
        var count = await source.CountAsync();
        var items = await source.ApplyPagination(paginationParams).ToListAsync();
        return new PaginatedList<T>(items, count, paginationParams);
    }
}