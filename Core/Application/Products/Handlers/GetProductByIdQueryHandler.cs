using CleanArchitecture.Core.Application.Products.Queries;
using CleanArchitecture.Core.Domain.Entities;
using CleanArchitecture.Core.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Application.Products.Handlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductRepository productRepository;

        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await productRepository.GetByIdAsync(request.Id);
        }
    }
}
