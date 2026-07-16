using SupportDesk.Core.Domain.Interfaces.Repositories;
using SupportDesk.Core.Domain.Models;

namespace SupportDeck.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IRepository<User>
    {
        public async Task AddAsync(User entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity is null");
            }
        }

        public Task DeleteAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
