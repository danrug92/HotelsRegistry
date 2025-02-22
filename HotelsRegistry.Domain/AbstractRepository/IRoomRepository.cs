using HotelsRegistry.Domain.Entities;


namespace HotelsRegistry.Domain.AbstractRepository
{
    public interface IRoomRepository : IRepository<Room>
    {
        IQueryable<Room> GetAllWithRoomTypeData();
        Task<Room?> GetRoomWithRoomTypeDataAsync(Guid Id);
    }
}
