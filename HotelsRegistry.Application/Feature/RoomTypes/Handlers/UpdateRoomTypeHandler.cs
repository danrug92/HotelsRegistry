using HotelsRegistry.Application.Feature.RoomTypes.Commands;
using HotelsRegistry.Application.Feature.RoomTypes.Mappers;
using HotelsRegistry.Domain.AbstractRepository;
using HotelsRegistry.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HotelsRegistry.Application.Feature.RoomTypes.Handlers
{
    public class UpdateRoomTypeHandler : IRequestHandler<UpdateRoomTypeCmd,bool>
    {
        private readonly IRoomTypeRepository _roomTypeRepo;

        public UpdateRoomTypeHandler(IRoomTypeRepository roomTypeRepo)
        {
            _roomTypeRepo = roomTypeRepo;
        }

        public async Task<bool> Handle(UpdateRoomTypeCmd cmd, CancellationToken cancellationToken)
        {
            var roomType = RoomTypeMapper.Mapper.Map<RoomType>(cmd);


            if (roomType is null)
            {
                throw new ApplicationException("There is an issue with mapping while creating new RoomType");

            }

            var roomTypesExist = await _roomTypeRepo.GetByIdAsync(roomType.Id);
            if (roomTypesExist == null)
            {
                throw new Exception("This roomType does not exist");
            }
            if (roomTypesExist.Accommmodation == null)
            {
                throw new ApplicationException("This room type does not have a valid accommodation");
            }
            try
            {
                roomType.CreateAt = roomTypesExist.CreateAt;
                roomType.UpdateAt = DateTime.UtcNow;
                await _roomTypeRepo.UpdateAsync(roomType);
                await _roomTypeRepo.SaveAllAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problem with RoomType update: " + ex.Message, ex);
            }
        }
    }
}
