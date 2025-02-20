
using HotelsRegistry.Application.Feature.Accommodations.Dto;
using MediatR;

namespace HotelsRegistry.Application.Feature.Accommodations.Queries
{
    public class GetAccommodationByIdQuery : IRequest<AccommodationDto>
    {
        public Guid Id { get; set; }
    }
}
