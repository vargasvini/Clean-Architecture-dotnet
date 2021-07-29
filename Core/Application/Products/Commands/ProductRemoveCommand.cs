using CleanArchitecture.Core.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Core.Application.Products.Commands
{
    public class ProductRemoveCommand : IRequest<Product>
    {
        public int Id { get; set; }
        public ProductRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
