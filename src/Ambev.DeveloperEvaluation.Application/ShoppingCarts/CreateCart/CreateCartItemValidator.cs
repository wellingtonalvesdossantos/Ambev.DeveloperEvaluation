using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.ShoppingCarts.CreateCart;

public class CreateCartItemValidator : AbstractValidator<CreateCartItemCommand>
{
    public CreateCartItemValidator()
    {
        RuleFor(x => x.ProductId)
            .NotEmpty()
            .WithMessage("ProductId cannot be empty");

        RuleFor(x => x.Quantity)
            .InclusiveBetween(1, 20)
            .WithMessage("Quantidade deve estar entre 1 e 20");
    }
}
