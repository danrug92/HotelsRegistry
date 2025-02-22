
using HotelsRegistry.Application.Feature.RoomHierarchys.Dto;
using MediatR;

namespace HotelsRegistry.Application.Feature.RoomHierarchys.Queries
{
    public class GetAllRoomHierarchyQuery : IRequest<IEnumerable<RoomHierarchyDto>>
    {
    }
}
