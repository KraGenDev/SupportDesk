using Microsoft.EntityFrameworkCore;
using SupportDesk.Core.Domain.Interfaces.Repositories;
using SupportDesk.Core.Domain.Models;

namespace SupportDeck.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
                throw new KeyNotFoundException($"User with Id:{id} not found");

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAsync() => await _context.Users.ToListAsync();

        public async Task UpdateAsync(User entity)
        {
            if(entity == null)
                throw new ArgumentNullException(nameof(entity));

            var user = await _context.Users.FindAsync(entity);

            if (user == null)
                throw new KeyNotFoundException($"User {entity.Name} not found");

            user.Name = entity.Name;
            user.Email = entity.Email;
            user.Role = entity.Role;
            user.PromoutedBy = entity.PromoutedBy;
            user.Password = entity.Password;

            await _context.SaveChangesAsync();
        }
    }
}
