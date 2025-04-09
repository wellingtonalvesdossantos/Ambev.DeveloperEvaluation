namespace Ambev.DeveloperEvaluation.WebApi.Features.ShoppingCarts.GetCart;

public class GetCartResponse
{
    public Guid Id { get; set; }
    public string Branch { get; set; } = string.Empty;
    public List<GetCartItemResponse> Items { get; set; } = [];
    public decimal TotalAmount { get; set; }
    public decimal TotalDiscount { get; set; }
    public decimal TotalAmountWithDiscount { get; set; }
}

public class GetCartItemResponse
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public bool IsCancelled { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalAmountWithDiscount { get; set; }
}