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
            var roomHierarchy = RoomHierarchyMapper.Mapper.Map<RoomHierarchy>(cmd);

            if (roomHierarchy is null)
            {
                throw new ApplicationException("There is an issue with mapping while creating new roomHierarchy");

            }
            try
            {
                if (!await _roomTypeRepo.ExistsAsync(cmd.RoomTypeBaseId) || !await _roomTypeRepo.ExistsAsync(cmd.RoomTypeRelatedId))
                {
                    throw new ApplicationException("Room type don't exist");
                }
            }
            catch
            {
                throw new ApplicationException("Problem with data context");

            }
            try
            {
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
