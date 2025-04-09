using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.ShoppingCarts.GetCart;

public class GetCartRequestValidator : AbstractValidator<GetCartRequest>
{
    public GetCartRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required.");
    }
}