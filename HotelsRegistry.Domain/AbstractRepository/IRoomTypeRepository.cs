using HotelsRegistry.Domain.Entities;


namespace HotelsRegistry.Domain.AbstractRepository
{
    public interface IRoomTypeRepository : IRepository<RoomType>
    {
        IQueryable<RoomType> GetAllWithAccommodationData();
        Task<RoomType?> GetRoomTypeWithAccommodationDataAsync(Guid Id);
    }
}
