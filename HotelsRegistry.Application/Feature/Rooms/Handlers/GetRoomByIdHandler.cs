using HotelsRegistry.Application.Feature.Rooms.Dto;
using HotelsRegistry.Application.Feature.Rooms.Mappers;
using HotelsRegistry.Application.Feature.Rooms.Queries;
using HotelsRegistry.Domain.AbstractRepository;
using MediatR;

namespace HotelsRegistry.Application.Feature.Rooms.Handlers
{
    public class GetRoomByIdHandler : IRequestHandler<GetRoomByIdQuery,RoomDto>
    {
        private readonly IRoomRepository _roomRepo;

        public GetRoomByIdHandler(IRoomRepository roomRepo)
        {
            _roomRepo = roomRepo;
        }

        public async Task<RoomDto> Handle(GetRoomByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var room = _roomRepo.GetRoomWithRoomTypeDataAsync(query.Id);
                var response = RoomMapper.Mapper.Map<RoomDto>(room);
                return response;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problem with retrieving data from context : " + ex.Message, ex);
            }
        }
    }
}
