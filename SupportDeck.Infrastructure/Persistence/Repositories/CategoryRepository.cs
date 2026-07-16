using SupportDesk.Core.Domain.Interfaces.Repositories;
using SupportDesk.Core.Domain.Models;

namespace SupportDeck.Infrastructure.Persistence.Repositories
{
    internal class CategoryRepository : IRepository<Category>
    {
        public Task AddAsync(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
