using Ambev.DeveloperEvaluation.WebApi.Common;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.FilterCart;

public class FilterCartRequestValidator : AbstractValidator<FilterCartRequest>
{
    public FilterCartRequestValidator()
    {
        //RuleFor(x => x.UserId)
        //    .NotEmpty()
        //    .WithMessage("UserId is required.");
    }
}