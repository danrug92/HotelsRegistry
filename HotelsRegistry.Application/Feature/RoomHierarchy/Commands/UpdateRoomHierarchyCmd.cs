using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HotelsRegistry.Application.Feature.RoomHierarchys.Commands
{
    public  class UpdateRoomHierarchyCmd : IRequest<bool>
    {
        public Guid Id { get; set; }
        public Guid RoomTypeBaseId { get; set; }
        public Guid RoomTypeRelatedId { get; set; }
        public decimal PercentageIncrease { get; set; } = 0;
    }
}
