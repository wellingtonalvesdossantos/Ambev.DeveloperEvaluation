using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.ShoppingCarts.GetCart;

public class GetCartHandler : IRequestHandler<GetCartCommand, GetCartResult>
{
    private readonly IShoppingCartRepository _shoppingCartRepository;
    private readonly IMapper _mapper;

    public GetCartHandler(IShoppingCartRepository shoppingCartRepository, IMapper mapper)
    {
        _shoppingCartRepository = shoppingCartRepository;
        _mapper = mapper;
    }

    public async Task<GetCartResult> Handle(GetCartCommand request, CancellationToken cancellationToken)
    {
        var shoppingCart = await _shoppingCartRepository.GetByIdAsync(request.Id);
        if (shoppingCart == null)
        {
            throw new KeyNotFoundException($"Shopping cart with id {request.Id} not found.");
        }
        return _mapper.Map<GetCartResult>(shoppingCart);
    }
}
