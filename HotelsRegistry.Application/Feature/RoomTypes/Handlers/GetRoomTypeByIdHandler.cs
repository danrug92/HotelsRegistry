using HotelsRegistry.Application.Feature.RoomTypes.Dto;
using HotelsRegistry.Application.Feature.RoomTypes.Mappers;
using HotelsRegistry.Application.Feature.RoomTypes.Queries;
using HotelsRegistry.Domain.AbstractRepository;
using MediatR;

namespace HotelsRegistry.Application.Feature.RoomTypes.Handlers
{
    public class GetRoomTypeByIdHandler : IRequestHandler<GetRoomTypeByIdQuery,RoomTypeDto>
    {
        private readonly IRoomTypeRepository _roomTypeRepo;

        public GetRoomTypeByIdHandler(IRoomTypeRepository roomTypeRepo)
        {
            _roomTypeRepo = roomTypeRepo;
        }

        public async Task<RoomTypeDto> Handle(GetRoomTypeByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var roomType = _roomTypeRepo.GetRoomTypeWithAccommodationDataAsync(query.Id);
                var response = RoomTypeMapper.Mapper.Map<RoomTypeDto>(roomType);
                return response;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problem with retrieving data from context : " + ex.Message, ex);
            }
        }
    }
}
