using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.ShoppingCarts.GetCart;

public class GetCartValidator : AbstractValidator<GetCartCommand>
{
    public GetCartValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Cart ID is required.");
    }
}
