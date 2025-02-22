using MediatR;

namespace HotelsRegistry.Application.Feature.RoomHierarchys.Commands
{
    public  class DeleteRoomHierarchyCmd : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
