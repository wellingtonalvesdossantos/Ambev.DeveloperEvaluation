using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Users.FilterUser
{
    internal class FilterUserValidator : AbstractValidator<FilterUserCommand>
    {
        /// <summary>
        /// Initializes validation rules for FilterUserCommand
        /// </summary>
        public FilterUserValidator()
        {
        }
    }
}
