using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HotelsRegistry.Application.Feature.RoomTypes.Commands
{
    public  class UpdateRoomTypeCmd : IRequest<bool>
    {
        public Guid Id { get; set; }
        public Guid AccommodationId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public int HierarchyLevel { get; set; } = 1;

    }
}
