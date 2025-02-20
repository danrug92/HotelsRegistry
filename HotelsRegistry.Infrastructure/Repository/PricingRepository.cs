using HotelsRegistry.Domain.AbstractRepository;
using HotelsRegistry.Domain.Entities;

namespace HotelsRegistry.Infrastructure.Repository
{
    public class PricingRepository : Repository<Pricing>, IPricingRepository
    {
        private readonly DataContext _context;

        public PricingRepository(DataContext context) : base(context)
        {
            this._context = context;
        }
    }
}
