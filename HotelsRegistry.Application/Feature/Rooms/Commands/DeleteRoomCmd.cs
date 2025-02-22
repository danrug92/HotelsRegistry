using MediatR;

namespace HotelsRegistry.Application.Feature.Rooms.Commands
{
    public  class DeleteRoomCmd : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
