using Ambev.DeveloperEvaluation.Domain.Common;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.ShoppingCarts.FilterCart;

public class FilterCartCommand : PaginatedSearchBase, IRequest<FilterCartResult>
{
    public Guid[]? CustomerList { get; set; }
    public Guid[]? ProductList { get; set; }
}
