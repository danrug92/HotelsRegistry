using HotelsRegistry.Application.Feature.RoomTypes.Dto;

namespace HotelsRegistry.Application.Feature.Pricings.Dto
{
    public class PricingDto
    {
        public Guid Id { get; set; }
        public RoomTypeDto? RoomType { get; set;}
        public decimal Price { get; set;}
        public DateTime StartDate { get; set;} 
        public DateTime EndDate { get; set; } 
        public bool IsSeasonal { get; set; }
    }
}
