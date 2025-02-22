using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HotelsRegistry.Application.Feature.Rooms.Commands
{
    public  class CreateRoomCmd : IRequest<bool>
    {
        public string? NameRoom { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? RoomInfo { get; set; }
        public Guid RoomTypeId { get; set; }
        public int RoomNumber { get; set; } = 0;
        public string? RoomCode { get; set; } = string.Empty;
        public double? SizeInSquareMeters { get; set; }
        public int? Capacity { get; set; }
        public int? Floor { get; set; }
        public bool IsAvailable { get; set; } = true;
        //public string? MediaRoomId { get; set; } Need storage
    }
}
