using Microsoft.EntityFrameworkCore;
using SupportDesk.Core.Domain.Interfaces.Repositories;
using SupportDesk.Core.Domain.Models;

namespace SupportDeck.Infrastructure.Persistence.Repositories
{
    internal class CategoryRepository : IRepository<Category>
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Category entity)
        {
            if(entity == null)
                throw new ArgumentNullException("Category is null");

            await _context.Categories.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);

            if(category == null)
                throw new KeyNotFoundException($"Category with id:{id} not found.");

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAsync() => await _context.Categories.ToListAsync();

        public async Task UpdateAsync(Category entity)
        {
            if(entity == null)
                throw new ArgumentNullException("Category is null");

            var category = await _context.Categories.FirstOrDefaultAsync(item => item.Id == entity.Id);
            if(category == null)
                throw new KeyNotFoundException("Category not found");

            category.Description = entity.Description;
            category.Name = entity.Name;
            category.Creator = entity.Creator;

            await _context.SaveChangesAsync();
        }
    }
}
