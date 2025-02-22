
using HotelsRegistry.Application.Feature.RoomHierarchys.Dto;
using MediatR;

namespace HotelsRegistry.Application.Feature.RoomHierarchys.Queries
{
    public class GetRoomHierarchyByIdQuery : IRequest<RoomHierarchyDto>
    {
        public Guid Id { get; set; }
        public GetRoomHierarchyByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
