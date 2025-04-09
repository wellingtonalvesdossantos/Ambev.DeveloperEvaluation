using MediatR;

namespace Ambev.DeveloperEvaluation.Application.ShoppingCarts.CreateCart;

public class CreateCartCommand : IRequest<CreateCartResult>
{
    public string Branch { get; set; } = string.Empty;
    public List<CreateCartItemCommand> Items { get; set; } = [];
}

public class CreateCartItemCommand
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}
