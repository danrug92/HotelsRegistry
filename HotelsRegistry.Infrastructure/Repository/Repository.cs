using HotelsRegistry.Domain.AbstractRepository;
using HotelsRegistry.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelsRegistry.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T>
        where T : class, IEntity
    {
        private readonly DataContext context;

        public Repository(DataContext context)
        {
            this.context = context;
        }

        public IQueryable<T> GetAll()
        {
            return this.context.Set<T>().AsNoTracking();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var model = await this.context.Set<T>()
                 .AsNoTracking()
                 .FirstOrDefaultAsync(e => e.Id == id);

            return model!;
        }

        public async Task CreateAsync(T entity)
        {
            await this.context.Set<T>().AddAsync(entity);
        }

        public Task UpdateAsync(T entity)
        {
            this.context.Set<T>().Update(entity);
            return Task.CompletedTask;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await this.context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var gettedElement = await this.GetByIdAsync(id);

            if (gettedElement != null)
            {
                this.context.Set<T>().Remove(gettedElement);
                await SaveAllAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> ExistsAsync(Guid id)
        {
            return await this.context.Set<T>().AnyAsync(e => e.Id == id);
        }
    }
}
