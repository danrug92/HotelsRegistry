﻿using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HotelsRegistry.Application.Feature.RoomTypes.Commands
{
    public  class CreateRoomTypeCmd : IRequest<bool>
    {
        public Guid AccommodationId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
    }
}
