﻿using HotelsRegistry.Application.Feature.Accommodations.Dto;
using HotelsRegistry.Application.Feature.RoomTypes.Dto;
using System.ComponentModel.DataAnnotations;

namespace HotelsRegistry.Application.Feature.Rooms.Dto
{
    public class RoomDto
    {
        public Guid Id { get; set; }
        public string? NameRoom { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? RoomInfo { get; set; }
        public int RoomNumber { get; set; } = 0;
        public string? RoomCode { get; set; } = string.Empty;
        public double? SizeInSquareMeters { get; set; }
        public int? Capacity { get; set; }
        public int? Floor { get; set; }
        public bool IsAvailable { get; set; } = true;
        //public string? MediaRoomId { get; set; }
        public RoomTypeDto? RoomType { get; set; }
    }
}
