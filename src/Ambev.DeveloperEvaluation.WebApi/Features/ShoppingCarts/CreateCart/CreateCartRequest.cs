namespace Ambev.DeveloperEvaluation.WebApi.Features.ShoppingCarts.CreateCart
{
    public class CreateCartRequest
    {
        public string Branch { get; set; } = string.Empty;
        public List<CreateCartItemRequest> Items { get; set; } = [];
    }

    public class CreateCartItemRequest
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}