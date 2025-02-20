using AutoMapper;
using HotelsRegistry.Application.Feature.Accommodations.Commands;
using HotelsRegistry.Application.Feature.Accommodations.Dto;
using HotelsRegistry.Domain.Entities;

namespace HotelsRegistry.Application.Feature.Accommodations.Mappers
{
    public class AccommodationMapProfile : Profile
    {
        public AccommodationMapProfile()
        {
            CreateMap<Accommodation, AccommodationDto>().ReverseMap();
            CreateMap<Accommodation, CreateAccommodationCmd>().ReverseMap();
            CreateMap<Accommodation, UpdateAccommodationCmd>().ReverseMap();
            CreateMap<IEnumerable<Accommodation>, IEnumerable<AccommodationDto>>().ReverseMap();
        }
    }
}
