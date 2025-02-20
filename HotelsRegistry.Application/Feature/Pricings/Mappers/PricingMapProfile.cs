using AutoMapper;
using HotelsRegistry.Application.Feature.Pricings.Dto;
using HotelsRegistry.Domain.Entities;

namespace HotelsRegistry.Application.Feature.Pricings.Mappers
{
    public class PricingMapProfile : Profile
    {
        public PricingMapProfile()
        {
            CreateMap<Pricing, PricingDto>().ReverseMap();
            CreateMap<IEnumerable<Pricing>, IEnumerable<PricingDto>>().ReverseMap();
        }
    }
}
