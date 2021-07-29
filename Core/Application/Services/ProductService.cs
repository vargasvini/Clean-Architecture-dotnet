using AutoMapper;
using CleanArchitecture.Core.Application.DTOs;
using CleanArchitecture.Core.Application.Interfaces;
using CleanArchitecture.Core.Domain.Entities;
using CleanArchitecture.Core.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task AddAsync(ProductDTO product)
        {
            var productEntity = mapper.Map<Product>(product);
            await productRepository.InsertAsync(productEntity);
        }

        public async Task<ProductDTO> GetByIdAsync(int? id)
        {
            var productEntity = await productRepository.GetByIdAsync(id);
            return mapper.Map<ProductDTO>(productEntity);
        }

        public async Task<ProductDTO> GetProductCategoryAsync(int? id)
        {
            var productEntity = await productRepository.GetProductCategoryAsync(id);
            return mapper.Map<ProductDTO>(productEntity);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            var productsEntity = await productRepository.GetProductsAsync();
            return mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
        }

        public async Task RemoveAsync(int? id)
        {
            var productEntity = productRepository.GetByIdAsync(id).Result;
            await productRepository.DeleteAsync(productEntity);
        }

        public async Task UpdateAsync(ProductDTO product)
        {
            var productEntity = mapper.Map<Product>(product);
            await productRepository.UpdateAsync(productEntity);
        }
    }
}
