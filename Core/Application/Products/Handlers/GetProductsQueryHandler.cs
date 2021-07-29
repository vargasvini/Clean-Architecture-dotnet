using CleanArchitecture.Core.Application.Products.Queries;
using CleanArchitecture.Core.Domain.Entities;
using CleanArchitecture.Core.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Application.Products.Handlers
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository productRepository;

        public GetProductsQueryHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await productRepository.GetProductsAsync();
        }
    }
}
