using Common.Serializer;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace HotelsRegistry.Domain.Entities
{
    public partial class Pricing : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid RoomTypeId { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Start date is required.")]
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        [Required(ErrorMessage = "End date is required.")]
        public DateTime EndDate { get; set; } = DateTime.UtcNow;
        public bool IsSeasonal { get; set; } = false;
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdateAt { get; set; } = DateTime.UtcNow;
        public virtual RoomType RoomType { get; set; }
    }
    public partial class Pricing
    {
        public static Pricing FromJson(string json) => JsonConvert.DeserializeObject<Pricing>(json, Converter.Settings) ?? new Pricing();
    }
}
