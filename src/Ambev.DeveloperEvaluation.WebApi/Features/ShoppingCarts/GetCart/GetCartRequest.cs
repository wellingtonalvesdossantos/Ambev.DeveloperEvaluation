namespace Ambev.DeveloperEvaluation.WebApi.Features.ShoppingCarts.GetCart;

public class GetCartRequest
{
    /// <summary>
    /// The ID of the cart to retrieve
    /// </summary>
    public Guid Id { get; set; }
}