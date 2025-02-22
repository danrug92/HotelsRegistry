using AutoMapper;
using HotelsRegistry.Application.Feature.Pricings.Commands;
using HotelsRegistry.Application.Feature.Pricings.Dto;
using HotelsRegistry.Application.Feature.RoomTypes.Dto;
using HotelsRegistry.Domain.Entities;

namespace HotelsRegistry.Application.Feature.Pricings.Mappers
{
    public class PricingMapProfile : Profile
    {
        public PricingMapProfile()
        {
            CreateMap<Pricing, PricingDto>()
           .ForMember(dest => dest.RoomType, opt => opt.MapFrom(src => src.RoomType))
           .ReverseMap();
            CreateMap<Pricing, PricingDto>().ReverseMap();
            CreateMap<Pricing, CreatePricingCmd>().ReverseMap();
            CreateMap<Pricing, UpdatePricingCmd>().ReverseMap();
            CreateMap<RoomType, RoomTypeDto>().ReverseMap();

        }
    }
}
