using HotelsRegistry.Domain.AbstractRepository;
using HotelsRegistry.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelsRegistry.Infrastructure.Repository
{
    public class RoomHierarchyRepository : Repository<RoomHierarchy>, IRoomHierarchyRepository
    {
        private readonly DataContext _context;

        public RoomHierarchyRepository(DataContext context) : base(context)
        {
            this._context = context;
        }

        public IQueryable<RoomHierarchy> GetAllWithRoomTypeData()
        {
            return GetAll().Include(rh => rh.RoomTypeBase).Include(rh => rh.RoomTypeRelated);

        }

        public async Task<RoomHierarchy?> GetHierarchyWithRoomTypeDataAsync(Guid Id)
        {
            return await _context.Set<RoomHierarchy>()
         .AsNoTracking().Include(rh => rh.RoomTypeBase).Include(rh => rh.RoomTypeRelated)
         .FirstOrDefaultAsync(e => e.Id == Id);
        }
    }
}