
using HotelsRegistry.Application.Feature.Rooms.Dto;
using MediatR;

namespace HotelsRegistry.Application.Feature.Rooms.Queries
{
    public class GetAllRoomQuery : IRequest<IEnumerable<RoomDto>>
    {
    }
}
