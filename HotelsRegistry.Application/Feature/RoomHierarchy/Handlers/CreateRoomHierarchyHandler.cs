using HotelsRegistry.Application.Feature.RoomHierarchys.Commands;
using HotelsRegistry.Application.Feature.RoomHierarchys.Mappers;
using HotelsRegistry.Domain.AbstractRepository;
using HotelsRegistry.Domain.Entities;
using MediatR;

namespace HotelsRegistry.Application.Feature.RoomHierarchys.Handlers
{
    public class CreateRoomHierarchyHandler : IRequestHandler<CreateRoomHierarchyCmd,bool>
    {
        private readonly IRoomHierarchyRepository _roomHierarchyRepo;
        private readonly IRoomTypeRepository _roomTypeRepo;
        public CreateRoomHierarchyHandler(IRoomHierarchyRepository roomHierarchyRepo, IRoomTypeRepository roomTypeRepo)
        {
            _roomHierarchyRepo = roomHierarchyRepo;
            _roomTypeRepo = roomTypeRepo;
        }

        public async Task<bool> Handle(CreateRoomHierarchyCmd cmd, CancellationToken cancellationToken)
        {
            var baseRoomType = await _roomTypeRepo.GetByIdAsync(cmd.RoomTypeBaseId);
            var relatedRoomType = await _roomTypeRepo.GetByIdAsync(cmd.RoomTypeRelatedId);

            if (baseRoomType == null || relatedRoomType == null)
            {
                throw new ApplicationException("One or both Room Types do not exist.");
            }
            if(baseRoomType.AccommodationId != relatedRoomType.AccommodationId)
            {
                throw new ApplicationException("the two types of rooms chosen do not belong to the same structure");
            }
            var lowerRoom = baseRoomType.HierarchyLevel <= relatedRoomType.HierarchyLevel ? baseRoomType : relatedRoomType;
            var higherRoom = baseRoomType.HierarchyLevel > relatedRoomType.HierarchyLevel ? baseRoomType : relatedRoomType;
            var roomHierarchy = RoomHierarchyMapper.Mapper.Map<RoomHierarchy>(cmd);

            if (roomHierarchy is null)
            {
                throw new ApplicationException("There is an issue with mapping while creating new hierarchy");

            }

            
            try
            {
                roomHierarchy.Id = Guid.NewGuid();
                roomHierarchy.CreateAt = DateTime.UtcNow;
                roomHierarchy.UpdateAt = DateTime.UtcNow;
                roomHierarchy.RoomTypeBaseId = lowerRoom.Id;
                roomHierarchy.RoomTypeRelatedId = higherRoom.Id;
                await _roomHierarchyRepo.CreateAsync(roomHierarchy);
                await _roomHierarchyRepo.SaveAllAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problem with roomHierarchy creation: " + ex.Message, ex);
            }
        }
    }
}
