using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.ShoppingCarts.CreateCart
{
    public class CreateCartHandler : IRequestHandler<CreateCartCommand, CreateCartResult>
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateCartHandler(IShoppingCartRepository shoppingCartRepository,
            IProductRepository productRepository, IMapper mapper)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CreateCartResult> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCartValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var cart = _mapper.Map<Domain.Entities.ShoppingCart>(request);

            var productIds = request.Items.Select(i => i.ProductId).Distinct().ToArray();
            var products = await _productRepository.GetByIdsAsync(productIds, cancellationToken);

            foreach (var item in cart.Items)
            {
                var product = products.FirstOrDefault(p => p.Id == item.ProductId);
                if (product == null)
                    throw new KeyNotFoundException($"Product with id {item.ProductId} not found.");
                item.UnitPrice = product.Price;
            }

            var createdCart = await _shoppingCartRepository.CreateAsync(cart, cancellationToken);
            createdCart = await _shoppingCartRepository.GetByIdAsync(createdCart.Id, cancellationToken);
            return _mapper.Map<CreateCartResult>(createdCart);
        }
    }
}
