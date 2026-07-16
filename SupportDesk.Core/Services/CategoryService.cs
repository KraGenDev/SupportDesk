using SupportDesk.Core.Domain.Interfaces.Repositories;
using SupportDesk.Core.Domain.Interfaces.Services;
using SupportDesk.Core.Domain.Models;

namespace SupportDesk.Core.Services
{
    internal class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _repository;

        public CategoryService(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task AddCategoryAsync(Category category)
        {
            if(category == null)
                throw new ArgumentNullException(nameof(category));

            await _repository.AddAsync(category);
        }

        public async Task DeleteCategoryAsync(Guid id)
        {
            if(id == Guid.Empty)
                throw new ArgumentNullException("Category Id can't be empty", nameof(id));

            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync() => await _repository.GetAsync();

        public async Task UpdateCategoryAsync(Category category)
        {
            if(category == null)
                throw new ArgumentNullException(nameof(category));

            await _repository.UpdateAsync(category);
        }
    }
}
