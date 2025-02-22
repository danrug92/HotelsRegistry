
using HotelsRegistry.Application.Feature.Rooms.Dto;
using MediatR;

namespace HotelsRegistry.Application.Feature.Rooms.Queries
{
    public class GetRoomByIdQuery : IRequest<RoomDto>
    {
        public Guid Id { get; set; }
        public GetRoomByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
