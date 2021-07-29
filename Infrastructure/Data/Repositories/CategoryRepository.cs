
using CleanArchitecture.Core.Domain.Entities;
using CleanArchitecture.Core.Domain.Interfaces;
using CleanArchitecture.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MainContext context;

        public CategoryRepository(MainContext context)
        {
            this.context = context;
        }

        public async Task<Category> DeleteAsync(Category category)
        {
            context.Remove(category);
            await context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> GetByIdAsync(int? id)
        {
            return await context.Categories.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task<Category> InsertAsync(Category category)
        {
            context.Add(category);
            await context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            context.Update(category);
            await context.SaveChangesAsync();
            return category;
        }
    }
}
