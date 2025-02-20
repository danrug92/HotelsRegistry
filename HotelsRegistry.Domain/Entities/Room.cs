using Common.Serializer;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace HotelsRegistry.Domain.Entities
{
    public partial class Room : IEntity
    {
        [Key]
        public Guid Id { get; set; }
       [StringLength(256, ErrorMessage = "Name cannot be longer than 256 characters.")]
        public string? NameRoom { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? RoomInfo { get; set; }
        [Required]
        public Guid RoomTypeId { get; set; } 

        [Required(ErrorMessage = "Room number is required.")]
        public int RoomNumber { get; set; }  = 0;
        public string? RoomCode { get; set; } = string.Empty;
        [Range(5, 500, ErrorMessage = "Size must be between 5 and 500 square meters.")]
        public double? SizeInSquareMeters { get; set; }
        public int? Capacity { get; set; }
        public int? Floor { get; set; }

        [Required(ErrorMessage = "Availability is required.")]
        public bool IsAvailable { get; set; } = true;
        public string? MediaRoomId { get; set; } //FK with db storage
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdateAt { get; set; } = DateTime.UtcNow;

        public virtual RoomType RoomType { get; set; }
    }
    public partial class Room
    {
        public static Room FromJson(string json) => JsonConvert.DeserializeObject<Room>(json, Converter.Settings) ?? new Room();
    }
}
