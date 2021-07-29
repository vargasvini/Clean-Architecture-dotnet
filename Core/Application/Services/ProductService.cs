using AutoMapper;
using CleanArchitecture.Core.Application.DTOs;
using CleanArchitecture.Core.Application.Interfaces;
using CleanArchitecture.Core.Application.Products.Commands;
using CleanArchitecture.Core.Application.Products.Handlers;
using CleanArchitecture.Core.Application.Products.Queries;
using CleanArchitecture.Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public ProductService(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        public async Task AddAsync(ProductDTO product)
        {
            var productCreateCommand = mapper.Map<ProductCreateCommand>(product);
            
            if (productCreateCommand == null)
                throw new Exception($"Entity could not be loaded");

            await mediator.Send(productCreateCommand);
        }

        public async Task<ProductDTO> GetByIdAsync(int? id)
        {
            var productsQuery = new GetProductByIdQuery(id.Value);

            if (productsQuery == null)
                throw new Exception($"Entity could not be loaded");

            var productEntity = await mediator.Send(productsQuery);

            return mapper.Map<ProductDTO>(productEntity);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            var productsQuery = new GetProductsQuery();

            if(productsQuery == null)
                throw new Exception($"Entity could not be loaded");

            var productsEntity = await mediator.Send(productsQuery);
            return mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
        }

        public async Task RemoveAsync(int? id)
        {
            var productRemoveCommand = new ProductRemoveCommand(id.Value);

            if (productRemoveCommand == null)
                throw new Exception($"Entity could not be loaded");

            await mediator.Send(productRemoveCommand);
        }

        public async Task UpdateAsync(ProductDTO product)
        {
            var productUpdateCommand = mapper.Map<ProductUpdateCommand>(product);

            if (productUpdateCommand == null)
                throw new Exception($"Entity could not be loaded");

            await mediator.Send(productUpdateCommand);
        }
    }
}
