
using HotelsRegistry.Application.Feature.Pricings.Dto;
using MediatR;

namespace HotelsRegistry.Application.Feature.Pricings.Queries
{
    public class GetAllPricingQuery : IRequest<IEnumerable<PricingDto>>
    {
    }
}
