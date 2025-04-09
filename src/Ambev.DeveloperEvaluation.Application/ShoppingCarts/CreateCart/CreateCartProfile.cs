namespace Ambev.DeveloperEvaluation.Application.ShoppingCarts.CreateCart;

public class CreateCartProfile : AutoMapper.Profile
{
    public CreateCartProfile()
    {
        CreateMap<CreateCartCommand, Domain.Entities.ShoppingCart>();
        CreateMap<CreateCartItemCommand, Domain.Entities.ShoppingCartItem>();
        CreateMap<Domain.Entities.ShoppingCart, CreateCartResult>();
        CreateMap<Domain.Entities.ShoppingCartItem, CreateCartItemResult>();
    }
}
