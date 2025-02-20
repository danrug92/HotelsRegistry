using HotelsRegistry.Domain.AbstractRepository;
using HotelsRegistry.Domain.Entities;

namespace HotelsRegistry.Infrastructure.Repository
{
    public class AccommodationRepository : Repository<Accommodation>, IAccommodationRepository
    {
        private readonly DataContext _context;

        public AccommodationRepository(DataContext context) : base(context)
        {
            this._context = context;
        }
    }
}
