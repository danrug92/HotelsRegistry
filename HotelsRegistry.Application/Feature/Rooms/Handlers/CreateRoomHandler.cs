using HotelsRegistry.Application.Feature.Rooms.Commands;
using HotelsRegistry.Application.Feature.Rooms.Mappers;
using HotelsRegistry.Domain.AbstractRepository;
using HotelsRegistry.Domain.Entities;
using MediatR;

namespace HotelsRegistry.Application.Feature.Rooms.Handlers
{
    public class CreateRoomHandler : IRequestHandler<CreateRoomCmd,bool>
    {
        private readonly IRoomRepository _roomRepo;
        private readonly IRoomTypeRepository _roomTypeRepo;
        public CreateRoomHandler(IRoomRepository roomRepo, IRoomTypeRepository roomTypeRepo)
        {
            _roomRepo = roomRepo;
            _roomTypeRepo = roomTypeRepo;
        }

        public async Task<bool> Handle(CreateRoomCmd cmd, CancellationToken cancellationToken)
        {
            var room = RoomMapper.Mapper.Map<Room>(cmd);

            if (room is null)
            {
                throw new ApplicationException("There is an issue with mapping while creating new room");

            }
            try
            {
                if (!await _roomTypeRepo.ExistsAsync(cmd.RoomTypeId))
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
                room.Id = Guid.NewGuid();
                room.CreateAt = DateTime.UtcNow;
                room.UpdateAt = DateTime.UtcNow;
                await _roomRepo.CreateAsync(room);
                await _roomRepo.SaveAllAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problem with room creation: " + ex.Message, ex);
            }
        }
    }
}
