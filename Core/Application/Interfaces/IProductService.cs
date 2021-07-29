using CleanArchitecture.Core.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProductsAsync();
        Task<ProductDTO> GetByIdAsync(int? id);
        Task AddAsync(ProductDTO product);
        Task UpdateAsync(ProductDTO product);
        Task RemoveAsync(int? id);
    }
}
