using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.ShoppingCarts.FilterCart;

public class FilterCartHandler : IRequestHandler<FilterCartCommand, FilterCartResult>
{
    private readonly IShoppingCartRepository _shoppingCartRepository;
    private readonly IMapper _mapper;
    
    public FilterCartHandler(IShoppingCartRepository shoppingCartRepository, IMapper mapper)
    {
        _shoppingCartRepository = shoppingCartRepository;
        _mapper = mapper;
    }

    public async Task<FilterCartResult> Handle(FilterCartCommand request, CancellationToken cancellationToken)
    {
        var validator = new FilterCartValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var query = _shoppingCartRepository.GetPaginated(request, request.CustomerList, request.ProductList);
        return await FilterCartResult.CreateAsync(request, query, _mapper);
    }
}
