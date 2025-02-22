using HotelsRegistry.Application.Feature.Rooms.Commands;
using HotelsRegistry.Application.Feature.Rooms.Mappers;
using HotelsRegistry.Domain.AbstractRepository;
using HotelsRegistry.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HotelsRegistry.Application.Feature.Rooms.Handlers
{
    public class UpdateRoomHandler : IRequestHandler<UpdateRoomCmd,bool>
    {
        private readonly IRoomRepository _roomRepo;

        public UpdateRoomHandler(IRoomRepository roomRepo)
        {
            _roomRepo = roomRepo;
        }

        public async Task<bool> Handle(UpdateRoomCmd cmd, CancellationToken cancellationToken)
        {
            var room = RoomMapper.Mapper.Map<Room>(cmd);


            if (room is null)
            {
                throw new ApplicationException("There is an issue with mapping while creating new Room");

            }
           
                var roomsExist = await _roomRepo.GetRoomWithRoomTypeDataAsync(room.Id);
                if(roomsExist == null)
                {
                    throw new Exception("This room does not exist");
                }
            if (roomsExist.RoomType == null)
            {
                throw new ApplicationException("This room does not have a valid room type");
            }
            try
            {
                room.CreateAt = roomsExist.CreateAt;
                room.UpdateAt = DateTime.UtcNow;
                await _roomRepo.UpdateAsync(room);
                await _roomRepo.SaveAllAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problem with Room update: " + ex.Message, ex);
            }
        }
    }
}
