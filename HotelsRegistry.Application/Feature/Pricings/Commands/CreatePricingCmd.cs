﻿using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HotelsRegistry.Application.Feature.Pricings.Commands
{
    public  class CreatePricingCmd : IRequest<bool>
    {
        public Guid RoomTypeId { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        public DateTime EndDate { get; set; } = DateTime.UtcNow;
        public bool IsSeasonal { get; set; } = false;
    }
}
