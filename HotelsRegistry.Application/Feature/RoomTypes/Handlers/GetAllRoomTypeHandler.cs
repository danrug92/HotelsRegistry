using HotelsRegistry.Application.Feature.RoomTypes.Dto;
using HotelsRegistry.Application.Feature.RoomTypes.Mappers;
using HotelsRegistry.Application.Feature.RoomTypes.Queries;
using HotelsRegistry.Domain.AbstractRepository;
using MediatR;

namespace HotelsRegistry.Application.Feature.RoomTypes.Handlers
{
    public class GetAllRoomTypeHandler : IRequestHandler<GetAllRoomTypeQuery,IEnumerable<RoomTypeDto>>
    {
        private readonly IRoomTypeRepository _roomTypeRepo;

        public GetAllRoomTypeHandler(IRoomTypeRepository roomTypeRepo)
        {
            _roomTypeRepo = roomTypeRepo;
        }

        public async Task<IEnumerable<RoomTypeDto>> Handle(GetAllRoomTypeQuery query, CancellationToken cancellationToken)
        {

            try
            {
                var roomTypesList = _roomTypeRepo.GetAllWithAccommodationData().ToList();
                var responseList = RoomTypeMapper.Mapper.Map<IEnumerable<RoomTypeDto>>(roomTypesList);
                return responseList;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problem with retrieving data from context : " + ex.Message, ex);
            }
        }
    }
}
