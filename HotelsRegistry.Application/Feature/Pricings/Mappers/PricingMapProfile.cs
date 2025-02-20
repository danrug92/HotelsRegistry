using AutoMapper;
using HotelsRegistry.Application.Feature.Pricings.Commands;
using HotelsRegistry.Application.Feature.Pricings.Dto;
using HotelsRegistry.Domain.Entities;

namespace HotelsRegistry.Application.Feature.Pricings.Mappers
{
    public class PricingMapProfile : Profile
    {
        public PricingMapProfile()
        {
            
            CreateMap<Pricing, PricingDto>().ReverseMap();
            CreateMap<Pricing, CreatePricingCmd>().ReverseMap();
            CreateMap<Pricing, UpdatePricingCmd>().ReverseMap();
            CreateMap<IEnumerable<Pricing>, IEnumerable<PricingDto>>().ReverseMap();
        }
    }
}
