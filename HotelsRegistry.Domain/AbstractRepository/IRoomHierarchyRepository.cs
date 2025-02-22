using HotelsRegistry.Domain.Entities;


namespace HotelsRegistry.Domain.AbstractRepository
{
    public interface IRoomHierarchyRepository : IRepository<RoomHierarchy>
    {
        IQueryable<RoomHierarchy> GetAllWithRoomTypeData();
        Task<RoomHierarchy?> GetHierarchyWithRoomTypeDataAsync(Guid Id);
    }
}
