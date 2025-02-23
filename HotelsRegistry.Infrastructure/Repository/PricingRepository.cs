using HotelsRegistry.Domain.AbstractRepository;
using HotelsRegistry.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelsRegistry.Infrastructure.Repository
{
    public class PricingRepository : Repository<Pricing>, IPricingRepository
    {
        private readonly DataContext _context;

        public PricingRepository(DataContext context) : base(context)
        {
            this._context = context;
        }

        public IQueryable<Pricing> GetAllWithRoomTypeData()
        {
            return GetAll().Include(p => p.RoomType);
        }

        public async Task<Pricing?> GetPricingWithRoomTypeDataAsync(Guid Id)
        {
            return await  _context.Set<Pricing>()
                 .AsNoTracking().Include(p => p.RoomType )
                 .FirstOrDefaultAsync(e => e.Id == Id);
        }
        public async Task<Pricing?> GetLatestPricingAsync(Guid roomTypeId)
        {
            return await _context.Set<Pricing>()
                .Where(p => p.RoomTypeId == roomTypeId)
                .OrderByDescending(p => p.CreateAt)
                .FirstOrDefaultAsync();
        }

    }
}
