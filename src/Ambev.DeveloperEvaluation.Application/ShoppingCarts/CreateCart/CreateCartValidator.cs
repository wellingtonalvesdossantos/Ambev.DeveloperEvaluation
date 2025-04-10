using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.ShoppingCarts.CreateCart;

public class CreateCartValidator : AbstractValidator<CreateCartCommand>
{
    public CreateCartValidator()
    {
        RuleFor(cart => cart.Branch)
            .NotEmpty()
            .WithMessage("Branch cannot be empty");

        RuleFor(x => x.Items)
            .NotNull()
            .NotEmpty()
            .WithMessage("Items cannot be empty");

        var itemValidator = new CreateCartItemValidator();
        RuleForEach(x => x.Items)
            .SetValidator(itemValidator);
    }
}
