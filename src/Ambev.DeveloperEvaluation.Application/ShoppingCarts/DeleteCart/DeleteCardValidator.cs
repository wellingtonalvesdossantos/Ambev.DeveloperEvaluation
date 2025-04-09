using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.ShoppingCarts.DeleteCart;

public class DeleteCartValidator : FluentValidation.AbstractValidator<DeleteCartCommand>
{
    public DeleteCartValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id cannot be empty");
    }
}