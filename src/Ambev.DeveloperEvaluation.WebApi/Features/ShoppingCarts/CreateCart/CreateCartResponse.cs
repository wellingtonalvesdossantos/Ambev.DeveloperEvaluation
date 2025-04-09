namespace Ambev.DeveloperEvaluation.WebApi.Features.ShoppingCarts.CreateCart;

public class CreateCartResponse
{
    public Guid Id { get; set; }
    public string Branch { get; set; } = string.Empty;
    public List<CreateCartItemResponse> Items { get; set; } = [];
    public decimal TotalAmount { get; set; }
    public decimal TotalDiscount { get; set; }
    public decimal TotalAmountWithDiscount { get; set; }
}

public class CreateCartItemResponse
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public bool IsCancelled { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalAmountWithDiscount { get; set; }
}