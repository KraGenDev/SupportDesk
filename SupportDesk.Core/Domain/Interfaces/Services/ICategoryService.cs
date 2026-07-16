using SupportDesk.Core.Domain.Models;


namespace SupportDesk.Core.Domain.Interfaces.Services
{
    public interface ICategoryService
    {
        Task AddCategoryAsync(Category category);
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task DeleteCategoryAsync(Guid id);
        Task UpdateCategoryAsync(Category category);
    }
}
