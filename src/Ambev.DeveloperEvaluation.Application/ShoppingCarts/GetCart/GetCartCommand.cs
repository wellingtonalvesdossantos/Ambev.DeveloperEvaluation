using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.ShoppingCarts.GetCart
{
    public class GetCartCommand : IRequest<GetCartResult>
    {
        public GetCartCommand(Guid id)
        {
            Id = id;
        }

        /// <summary>
        /// The unique identifier of the shoppingCart to retrieve
        /// </summary>
        public Guid Id { get; }

    }
}
