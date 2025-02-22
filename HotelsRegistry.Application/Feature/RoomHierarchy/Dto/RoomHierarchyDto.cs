using HotelsRegistry.Application.Feature.RoomTypes.Dto;

namespace HotelsRegistry.Application.Feature.RoomHierarchys.Dto
{
    public class RoomHierarchyDto
    {
        public Guid Id { get; set; }
        public decimal PercentageIncrease { get; set; } = 0;
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdateAt { get; set; } = DateTime.UtcNow;
        public  RoomTypeDto? RoomTypeBase { get; set; }
        public  RoomTypeDto? RoomTypeRelated { get; set; }
    }
}
