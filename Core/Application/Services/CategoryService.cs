using AutoMapper;
using CleanArchitecture.Core.Application.DTOs;
using CleanArchitecture.Core.Application.Interfaces;
using CleanArchitecture.Core.Domain.Entities;
using CleanArchitecture.Core.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Application.Services
{
    public class CategoryService : ICategoryService
    {
        public readonly ICategoryRepository categoryRepository;
        public readonly IMapper mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public async Task AddAsync(CategoryDTO category)
        {
            var categoryEntity = mapper.Map<Category>(category);
            await categoryRepository.InsertAsync(categoryEntity);
        }

        public async Task<CategoryDTO> GetByIdAsync(int? id)
        {
            var categoryEntity = await categoryRepository.GetByIdAsync(id);
            return mapper.Map<CategoryDTO>(categoryEntity);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
        {
            var categoriesEntity = await categoryRepository.GetCategoriesAsync();
            return mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }

        public async Task RemoveAsync(int? id)
        {
            var categoryEntity = categoryRepository.GetByIdAsync(id).Result;
            await categoryRepository.DeleteAsync(categoryEntity);
        }

        public async Task UpdateAsync(CategoryDTO category)
        {
            var categoryEntity = mapper.Map<Category>(category);
            await categoryRepository.UpdateAsync(categoryEntity);
        }
    }
}
