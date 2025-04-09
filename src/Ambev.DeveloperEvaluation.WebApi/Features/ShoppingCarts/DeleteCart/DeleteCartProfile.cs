using Ambev.DeveloperEvaluation.Application.ShoppingCarts.DeleteCart;

namespace Ambev.DeveloperEvaluation.WebApi.Features.ShoppingCarts.DeleteCart;

public class DeleteCartProfile : AutoMapper.Profile
{
    public DeleteCartProfile()
    {
        CreateMap<Guid, DeleteCartCommand>()
            .ConstructUsing(id => new DeleteCartCommand(id));
    }
}