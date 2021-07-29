using CleanArchitecture.Core.Application.Products.Commands;
using CleanArchitecture.Core.Domain.Entities;
using CleanArchitecture.Core.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Application.Products.Handlers
{
    public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, Product>
    {
        private readonly IProductRepository productRepository;

        public ProductCreateCommandHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<Product> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(
                request.Name,
                request.Description,
                request.Price,
                request.Stock,
                request.Image
            );

            if(product == null)
            {
                throw new ApplicationException($"Error creating entity");
            }
            else
            {
                product.CategoryId = request.CategoryId;
                return await productRepository.InsertAsync(product);
            }
        }
    }
}
