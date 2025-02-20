using HotelsRegistry.Domain.AbstractRepository;
using HotelsRegistry.Domain.Entities;

namespace HotelsRegistry.Infrastructure.Repository
{
    public class RoomTypeRepository : Repository<RoomType>, IRoomTypeRepository
    {
        private readonly DataContext _context;

        public RoomTypeRepository(DataContext context) : base(context)
        {
            this._context = context;
        }
    }
}
