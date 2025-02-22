using HotelsRegistry.Application.Feature.Rooms.Dto;
using HotelsRegistry.Application.Feature.Rooms.Mappers;
using HotelsRegistry.Application.Feature.Rooms.Queries;
using HotelsRegistry.Domain.AbstractRepository;
using MediatR;

namespace HotelsRegistry.Application.Feature.Rooms.Handlers
{
    public class GetAllRoomHandler : IRequestHandler<GetAllRoomQuery,IEnumerable<RoomDto>>
    {
        private readonly IRoomRepository _roomRepo;

        public GetAllRoomHandler(IRoomRepository roomRepo)
        {
            _roomRepo = roomRepo;
        }

        public async Task<IEnumerable<RoomDto>> Handle(GetAllRoomQuery query, CancellationToken cancellationToken)
        {

            try
            {
                var roomsList = _roomRepo.GetAllWithRoomTypeData().ToList();
                var responseList = RoomMapper.Mapper.Map<IEnumerable<RoomDto>>(roomsList);
                return responseList;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problem with retrieving data from context : " + ex.Message, ex);
            }
        }
    }
}
