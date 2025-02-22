using HotelsRegistry.Application.Feature.RoomTypes.Commands;
using HotelsRegistry.Application.Feature.RoomTypes.Mappers;
using HotelsRegistry.Domain.AbstractRepository;
using HotelsRegistry.Domain.Entities;
using MediatR;

namespace HotelsRegistry.Application.Feature.RoomTypes.Handlers
{
    public class CreateRoomTypeHandler : IRequestHandler<CreateRoomTypeCmd,bool>
    {
        private readonly IRoomTypeRepository _roomTypeRepo;
        private readonly IAccommodationRepository _accommodationRepo;

        public CreateRoomTypeHandler(IRoomTypeRepository roomTypeRepo, IAccommodationRepository accommodationRepo)
        {
            _roomTypeRepo = roomTypeRepo;
            _accommodationRepo = accommodationRepo;
        }

        public async Task<bool> Handle(CreateRoomTypeCmd cmd, CancellationToken cancellationToken)
        {
            var roomType = RoomTypeMapper.Mapper.Map<RoomType>(cmd);

            if (roomType is null)
            {
                throw new ApplicationException("There is an issue with mapping while creating new roomType");

            }
            try
            {
                if (!await _accommodationRepo.ExistsAsync(cmd.AccommodationId))
                {
                    throw new ApplicationException("Accommodation don't exist");
                }
            }
            catch
            {
                throw new ApplicationException("Problem with data context");

            }
            try
            {
                roomType.Id = Guid.NewGuid();
                roomType.CreateAt = DateTime.UtcNow;
                roomType.UpdateAt = DateTime.UtcNow;
                await _roomTypeRepo.CreateAsync(roomType);
                await _roomTypeRepo.SaveAllAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problem with roomType creation: " + ex.Message, ex);
            }
        }
    }
}
