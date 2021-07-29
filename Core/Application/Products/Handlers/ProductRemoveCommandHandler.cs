using CleanArchitecture.Core.Application.Products.Commands;
using CleanArchitecture.Core.Domain.Entities;
using CleanArchitecture.Core.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Application.Products.Handlers
{
    public class ProductRemoveCommandHandler : IRequestHandler<ProductRemoveCommand, Product>
    {
        private readonly IProductRepository productRepository;

        public ProductRemoveCommandHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<Product> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByIdAsync(request.Id);

            if (product == null)
            {
                throw new ApplicationException($"Error creating entity");
            }
            else
            {
                return await productRepository.DeleteAsync(product);
            }
        }
    }
}
