using HotelsRegistry.Domain.AbstractRepository;
using HotelsRegistry.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelsRegistry.Infrastructure.Repository
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        private readonly DataContext _context;

        public RoomRepository(DataContext context) : base(context)
        {
            this._context = context;
        }

        public IQueryable<Room> GetAllWithRoomTypeData()
        {
            return GetAll().Include(r => r.RoomType);

        }

        public async Task<Room?> GetRoomWithRoomTypeDataAsync(Guid Id)
        {
            return await _context.Set<Room>()
         .AsNoTracking().Include(r => r.RoomType)
         .FirstOrDefaultAsync(e => e.Id == Id);
        }
    }
}
