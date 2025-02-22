﻿using HotelsRegistry.Application.Feature.Accommodations.Dto;

namespace HotelsRegistry.Application.Feature.RoomTypes.Dto
{
    public class RoomTypeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public  AccommodationDto? Accommmodation { get; set; }
    }
}
