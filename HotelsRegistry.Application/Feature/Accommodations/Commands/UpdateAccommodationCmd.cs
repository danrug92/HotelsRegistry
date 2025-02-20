using HotelsRegistry.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HotelsRegistry.Application.Feature.Accommodations.Commands
{
    public  class UpdateAccommodationCmd : IRequest<bool>
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Country is required.")]
        public string Country { get; set; } = string.Empty;
        [Display(Name = "Coordinate", Description = "Please enter latitude and longitude (e.g., 41.154214 , 12.456432).")]
        public string? Coordinate { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone is required.")]
        [Display(Name = "Phone Number", Description = "Please enter your phone number with country code (e.g., +1 234 567 890).")]
        [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "Invalid phone number format.")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "VAT Number is required.")]
        [StringLength(20, ErrorMessage = "VAT Number cannot be longer than 50 characters.")]
        public string VatNumber { get; set; } = string.Empty;

        public bool IsPartOfChain { get; set; } = false;

        [Required(ErrorMessage = "Stars rating is required.")]
        [Range(1, 5, ErrorMessage = "Stars must be between 1 and 5.")]
        public int Stars { get; set; } = 1;
        public AccommodationType Type { get; set; }
    }
}
