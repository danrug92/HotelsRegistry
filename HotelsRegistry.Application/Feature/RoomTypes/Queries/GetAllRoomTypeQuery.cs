
using HotelsRegistry.Application.Feature.RoomTypes.Dto;
using MediatR;

namespace HotelsRegistry.Application.Feature.RoomTypes.Queries
{
    public class GetAllRoomTypeQuery : IRequest<IEnumerable<RoomTypeDto>>
    {
    }
}
