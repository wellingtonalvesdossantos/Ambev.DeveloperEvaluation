using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> ApplyPagination<T>(this IQueryable<T> query, PaginatedSearchBase paginationParams)
        {
            var page = paginationParams.CurrentPage.GetValueOrDefault(1);
            var size = paginationParams.PageSize.GetValueOrDefault(paginationParams.DefaultPageSize);
            var skip = (page - 1) * size;
            return query.Skip(skip).Take(size);
        }
    }
}
