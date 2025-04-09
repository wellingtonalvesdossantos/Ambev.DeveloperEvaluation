using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.FilterUser;

/// <summary>
/// Validator for FilterUserRequest
/// </summary>
public class FilterUserRequestValidator : AbstractValidator<FilterUserRequest>
{
    /// <summary>
    /// Initializes validation rules for FilterUserRequest
    /// </summary>
    public FilterUserRequestValidator()
    {
    }
}