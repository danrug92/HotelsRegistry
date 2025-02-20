using Common.Serializer;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace HotelsRegistry.Domain.Entities
{
    public partial class RoomHierarchy : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid RoomTypeBaseId { get; set; }
        [Required]
        public Guid RoomTypeRelatedId { get; set; }
        [Required(ErrorMessage = "Percentage increase is required.")]
        public decimal PercentageIncrease { get; set; } = 0;
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdateAt { get; set; } = DateTime.UtcNow;

        public virtual RoomType RoomTypeBase { get; set; }
        public virtual RoomType RoomTypeRelated { get; set; }
    }
    public partial class RoomHierarchy
    {
        public static RoomHierarchy FromJson(string json) => JsonConvert.DeserializeObject<RoomHierarchy>(json, Converter.Settings) ?? new RoomHierarchy();
    }
}
