using HotelsRegistry.Domain.AbstractRepository;
using HotelsRegistry.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelsRegistry.Infrastructure.Repository
{
    public class RoomTypeRepository : Repository<RoomType>, IRoomTypeRepository
    {
        private readonly DataContext _context;

        public RoomTypeRepository(DataContext context) : base(context)
        {
            this._context = context;
        }

        public IQueryable<RoomType> GetAllWithAccommodationData()
        {
            return GetAll().Include(rt => rt.Accommmodation);
        }

        public async Task<RoomType?> GetRoomTypeWithAccommodationDataAsync(Guid Id)
        {
            return await _context.Set<RoomType>()
        .AsNoTracking().Include(p => p.Accommmodation)
        .FirstOrDefaultAsync(e => e.Id == Id);
        }
    }
}