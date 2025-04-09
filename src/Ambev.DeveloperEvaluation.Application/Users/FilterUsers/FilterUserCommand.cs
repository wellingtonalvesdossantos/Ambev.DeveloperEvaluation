using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Users.FilterUser
{
    public class FilterUserCommand : PaginatedSearchBase, IRequest<FilterUserResult>
    {
        public UserRole[]? RoleList { get; set; }

        public UserStatus[]? StatusList { get; set; }
    }
}
