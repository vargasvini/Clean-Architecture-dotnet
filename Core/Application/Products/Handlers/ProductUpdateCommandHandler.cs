using CleanArchitecture.Core.Application.Products.Commands;
using CleanArchitecture.Core.Domain.Entities;
using CleanArchitecture.Core.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Application.Products.Handlers
{
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Product>
    {
        private readonly IProductRepository productRepository;

        public ProductUpdateCommandHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByIdAsync(request.Id);

            if (product == null)
            {
                throw new ApplicationException($"Error creating entity");
            }
            else
            {
                product.Update(
                      request.Name,
                      request.Description,
                      request.Price,
                      request.Stock,
                      request.Image,
                      request.CategoryId
                );
                return await productRepository.UpdateAsync(product);
            }
        }
    }
}
