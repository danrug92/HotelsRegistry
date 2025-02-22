using HotelsRegistry.Domain.Entities;


namespace HotelsRegistry.Domain.AbstractRepository
{
    public interface IPricingRepository : IRepository<Pricing>
    {
        IQueryable<Pricing> GetAllWithRoomTypeData();
        Task<Pricing?> GetPricingWithRoomTypeDataAsync(Guid Id);
    }
}
