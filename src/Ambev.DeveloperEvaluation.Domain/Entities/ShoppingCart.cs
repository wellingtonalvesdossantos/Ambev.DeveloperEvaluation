using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class ShoppingCart : BaseEntity
{
    public decimal TotalAmount => Items.Sum(item => item.TotalAmount);
    public decimal TotalDiscount => Items.Sum(item => item.Discount);
    public decimal TotalAmountWithDiscount => TotalAmount - TotalDiscount;

    public string Branch { get; set; } = string.Empty;
    public ICollection<ShoppingCartItem> Items { get; set; } = [];
}
