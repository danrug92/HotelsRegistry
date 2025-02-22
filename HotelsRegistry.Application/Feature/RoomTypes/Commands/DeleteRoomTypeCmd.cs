using MediatR;

namespace HotelsRegistry.Application.Feature.RoomTypes.Commands
{
    public  class DeleteRoomTypeCmd : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
