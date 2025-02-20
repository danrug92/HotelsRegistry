using Common.Serializer;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace HotelsRegistry.Domain.Entities
{
    public partial class Accommodation : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(256, ErrorMessage = "Name cannot be longer than 256 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required.")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Country is required.")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string Country { get; set; } = string.Empty;
        public string? Coordinate { get; set; } = string.Empty;
        [Required(ErrorMessage = "Phone is required.")]
        [Display(Name = "Phone Number", Description = "Please enter your phone number with country code (e.g., +1 234 567 890).")]
        [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "Invalid phone number format.")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [StringLength(100, ErrorMessage = "Email cannot be longer than 100 characters.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = string.Empty;
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdateAt { get; set; } = DateTime.UtcNow;
        public virtual ICollection<RoomType>? RoomTypes { get; set; }
    }
    public partial class Accommodation
    {
        public static Accommodation FromJson(string json) => JsonConvert.DeserializeObject<Accommodation>(json, Converter.Settings) ?? new Accommodation();
    }
}
