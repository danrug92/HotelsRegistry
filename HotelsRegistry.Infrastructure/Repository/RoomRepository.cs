using HotelsRegistry.Domain.AbstractRepository;
using HotelsRegistry.Domain.Entities;

namespace HotelsRegistry.Infrastructure.Repository
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        private readonly DataContext _context;

        public RoomRepository(DataContext context) : base(context)
        {
            this._context = context;
        }
    }
}
