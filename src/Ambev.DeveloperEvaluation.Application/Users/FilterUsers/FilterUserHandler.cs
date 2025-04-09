using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Users.FilterUser
{
    public class FilterUserHandler : IRequestHandler<FilterUserCommand, FilterUserResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public FilterUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<FilterUserResult> Handle(FilterUserCommand request, CancellationToken cancellationToken)
        {
            var validator = new FilterUserValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var query = _userRepository.GetPaginated(request, request.RoleList, request.StatusList);

            return await FilterUserResult.CreateAsync(request, query, _mapper);
        }
    }
}
