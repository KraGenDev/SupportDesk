using SupportDesk.Core.Domain.Interfaces.Repositories;
using SupportDesk.Core.Domain.Interfaces.Services;
using SupportDesk.Core.Domain.Models;

namespace SupportDesk.Core.Services
{
    internal class UserService : IUserService
    {
        private readonly IRepository<User> _repository;

        public UserService(IRepository<User> repository) 
        { 
            _repository = repository;
        }

        public async Task AddUserAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            await _repository.AddAsync(user);
        }

        public async Task DeleteUserAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException("User Id can`t be empty.",nameof(id));

            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _repository.GetAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            if(user == null) 
                throw new ArgumentNullException("User can't be null for updating",nameof(user));

            await _repository.UpdateAsync(user);
        }
    }
}
