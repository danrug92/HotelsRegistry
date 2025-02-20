
namespace HotelsRegistry.Domain.AbstractRepository
{
    public interface IRepository<T>
        where T : class
    {
        IQueryable<T> GetAll();

        Task<T> GetByIdAsync(Guid id);

        Task CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task<bool> SaveAllAsync();

        Task<bool> DeleteAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
    }
}
