
using HotelsRegistry.Domain.Entities;

namespace HotelsRegistry.Application.Feature.Accommodations.Dto
{
    public class AccommodationDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string? Coordinate { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string VatNumber { get; set; } = string.Empty;
        public bool IsPartOfChain { get; set; } = false;
        public int Stars { get; set; } = 1;
        public string Type { get; set; } = string.Empty;
    }
}
