using HotelsRegistry.Domain.AbstractRepository;
using HotelsRegistry.Domain.Entities;

namespace HotelsRegistry.Infrastructure.Repository
{
    public class RoomHierarchyRepository : Repository<RoomHierarchy>, IRoomHierarchyRepository
    {
        private readonly DataContext _context;

        public RoomHierarchyRepository(DataContext context) : base(context)
        {
            this._context = context;
        }
    }
}
