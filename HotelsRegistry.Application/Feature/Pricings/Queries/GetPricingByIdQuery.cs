
using HotelsRegistry.Application.Feature.Pricings.Dto;
using MediatR;

namespace HotelsRegistry.Application.Feature.Pricings.Queries
{
    public class GetPricingByIdQuery : IRequest<PricingDto>
    {
        public Guid Id { get; set; }
    }
}
