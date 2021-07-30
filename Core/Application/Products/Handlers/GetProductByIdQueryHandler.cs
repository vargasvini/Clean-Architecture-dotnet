using CleanArchitecture.Core.Application.Products.Queries;
using CleanArchitecture.Core.Domain.Entities;
using CleanArchitecture.Core.Domain.Interfaces;
using MediatR;
using ServiceStack.Redis;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Application.Products.Handlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductRepository productRepository;
        private IRedisClient redisClient;

        public GetProductByIdQueryHandler(IProductRepository productRepository, IRedisClient redisClient)
        {
            this.productRepository = productRepository;
            this.redisClient = redisClient;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            Product productResult;
            productResult = redisClient.Get<Product>(request.Id.ToString());

            if(productResult == null)
            {
                var productRepo = await productRepository.GetByIdAsync(request.Id);
                if (productRepo != null)
                {
                    productResult = productRepo;
                    redisClient.Set<Product>(productRepo.Id.ToString(), productRepo);
                }
            }

            return productResult;
        }
    }
}
