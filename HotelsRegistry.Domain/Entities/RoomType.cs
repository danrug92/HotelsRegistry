using Common.Serializer;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
namespace HotelsRegistry.Domain.Entities
{
    public partial class RoomType : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid AccommodationId { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(256, ErrorMessage = "Name cannot be longer than 256 characters.")]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public int HierarchyLevel { get; set; } = 1;
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdateAt { get; set; } = DateTime.UtcNow;
        public virtual Accommodation? Accommmodation { get; set; }  
        public virtual ICollection<Room>? Rooms { get; set; }  
        public virtual ICollection<RoomHierarchy>? RoomHierarchies { get; set; }  
        public virtual ICollection<Pricing>? Pricings { get; set; }  
    }
    public partial class RoomType
    {
        public static RoomType FromJson(string json) => JsonConvert.DeserializeObject<RoomType>(json, Converter.Settings) ?? new RoomType();
    }
}
