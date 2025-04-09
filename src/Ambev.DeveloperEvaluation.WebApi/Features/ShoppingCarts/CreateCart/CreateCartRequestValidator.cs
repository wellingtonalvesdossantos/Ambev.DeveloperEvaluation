using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.ShoppingCarts.CreateCart;

public class CreateCartRequestValidator : AbstractValidator<CreateCartRequest>
{
    public CreateCartRequestValidator()
    {
        RuleFor(x => x.Items)
            .NotEmpty()
            .WithMessage("Items are required.");
    }
}