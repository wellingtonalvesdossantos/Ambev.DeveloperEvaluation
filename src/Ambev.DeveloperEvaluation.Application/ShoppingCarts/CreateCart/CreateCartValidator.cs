using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.ShoppingCarts.CreateCart;

public class CreateCartValidator : AbstractValidator<CreateCartCommand>
{
    public CreateCartValidator()
    {
        RuleFor(x => x.Items)
            .NotNull()
            .NotEmpty()
            .WithMessage("Items cannot be null");
    }
}
