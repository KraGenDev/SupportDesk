namespace SupportDesk.Core.Domain.Interfaces.Repositories
{
    public interface IRepository <T> where T : class
    {
        Task<IEnumerable<T>> GetAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
    }
}
