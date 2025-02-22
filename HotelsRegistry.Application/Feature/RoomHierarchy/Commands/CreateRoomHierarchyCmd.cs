using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HotelsRegistry.Application.Feature.RoomHierarchys.Commands
{
    public  class CreateRoomHierarchyCmd : IRequest<bool>
    {
        public Guid RoomTypeBaseId { get; set; }
        public Guid RoomTypeRelatedId { get; set; }
        public decimal PercentageIncrease { get; set; } = 0;
    }
}
