using Ambev.DeveloperEvaluation.Application.Users.FilterUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.GetUser;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.FilterUser;

public class FilterUserProfile : Profile
{
    public FilterUserProfile()
    {
        CreateMap<FilterUserRequest, FilterUserCommand>();
        //CreateMap<FilterUserResult, FilterUserResponse>();
    }
}