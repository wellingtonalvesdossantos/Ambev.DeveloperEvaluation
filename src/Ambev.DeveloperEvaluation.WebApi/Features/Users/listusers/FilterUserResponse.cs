using Ambev.DeveloperEvaluation.Application.Users.FilterUser;
using Ambev.DeveloperEvaluation.Application.Users.GetUser;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.GetUser;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.FilterUser;

/// <summary>
/// API response model for GetPaginated operation
/// </summary>
public class FilterUserResponse : PaginatedResponse<GetUserResponse>
{
    public static FilterUserResponse Create(FilterUserResult result, IMapper mapper)
    {
        var data = mapper.Map<List<GetUserResponse>>(result);
        return new()
        {
            CurrentPage = result.CurrentPage,
            TotalPages = result.TotalPages,
            TotalCount = result.TotalCount,
            Data = data,
            Success = true,
            Message = "Users retrieved successfully",
        };
    }
}