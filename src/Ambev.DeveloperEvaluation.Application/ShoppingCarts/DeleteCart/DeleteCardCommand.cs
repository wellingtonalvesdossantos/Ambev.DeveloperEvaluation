using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.ShoppingCarts.DeleteCart
{
    public class DeleteCartCommand : IRequest<DeleteCartResult>
    {
        public DeleteCartCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
