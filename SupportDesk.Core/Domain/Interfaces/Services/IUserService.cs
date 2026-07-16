using SupportDesk.Core.Domain.Models;

namespace SupportDesk.Core.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task AddUserAsync(User user);
        Task DeleteUserAsync(Guid id);
        Task UpdateUserAsync(User user);
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
