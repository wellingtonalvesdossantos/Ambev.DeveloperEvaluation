using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.FilterCart;

public class FilterCartRequest : PaginatedSearchBase
{
    public Guid[]? CustomerList { get; set; }
    public Guid[]? ProductList { get; set; }
}