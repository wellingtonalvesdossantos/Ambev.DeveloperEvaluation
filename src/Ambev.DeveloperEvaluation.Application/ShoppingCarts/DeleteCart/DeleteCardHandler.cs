using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.ShoppingCarts.DeleteCart;

public class DeleteCartHandler : IRequestHandler<DeleteCartCommand, DeleteCartResult>
{
    private readonly IShoppingCartRepository _shoppingCartRepository;

    public DeleteCartHandler(IShoppingCartRepository shoppingCartRepository)
    {
        _shoppingCartRepository = shoppingCartRepository;
    }

    public async Task<DeleteCartResult> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteCartValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var sucess = await _shoppingCartRepository.DeleteAsync(request.Id);
        if (!sucess)
            throw new KeyNotFoundException($"Shopping cart with id {request.Id} not found.");

        return new DeleteCartResult() { Success = true };
    }
}
