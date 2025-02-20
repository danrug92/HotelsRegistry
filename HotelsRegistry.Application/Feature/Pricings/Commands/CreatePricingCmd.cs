using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HotelsRegistry.Application.Feature.Pricings.Commands
{
    public  class CreatePricingCmd : IRequest<bool>
    {
        [Required(ErrorMessage = "Room Type Id is required.")]

        public Guid RoomTypeId { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Start date is required.")]
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        [Required(ErrorMessage = "End date is required.")]
        public DateTime EndDate { get; set; } = DateTime.UtcNow;
        public bool IsSeasonal { get; set; } = false;
    }
}
