using Ambev.DeveloperEvaluation.Application.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.FilterUser;

public class FilterUserRequest : PaginatedSearchRequest
{
    /// <summary>
    /// Gets or sets the list of user roles to filter by.
    /// </summary>
    public UserRole[]? RoleList { get; set; }

    /// <summary>
    /// Gets or sets the list of user statuses to filter by.
    /// </summary>
    public UserStatus[]? StatusList { get; set; }
}