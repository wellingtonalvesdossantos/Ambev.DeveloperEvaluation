using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class ShoppingCartItem : BaseEntity
{
    public Guid CartId { get; set; }
    public ShoppingCart Cart { get; set; } = default!;
    public Guid ProductId { get; set; }
    public Product Product { get; set; } = default!;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public bool IsCancelled { get; set; }

    public decimal TotalAmount => UnitPrice * Quantity;

    public decimal Discount => GetDiscount();

    public decimal TotalAmountWithDiscount => TotalAmount - Discount;

    private decimal GetDiscount()
    {
        return TotalAmount * (Quantity switch
        {
            > 4 and < 10 => 0.1m,
            >= 10 and <= 20 => 0.2m,
            _ => 1,
        });
    }
}
