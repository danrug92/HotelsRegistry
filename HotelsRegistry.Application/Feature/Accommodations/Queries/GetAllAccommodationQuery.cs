
using HotelsRegistry.Application.Feature.Accommodations.Dto;
using MediatR;

namespace HotelsRegistry.Application.Feature.Accommodations.Queries
{
    public class GetAllAccommodationQuery : IRequest<IEnumerable<AccommodationDto>>
    {
    }
}
