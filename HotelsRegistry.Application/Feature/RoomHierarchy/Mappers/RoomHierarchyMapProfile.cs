using AutoMapper;
using HotelsRegistry.Application.Feature.RoomHierarchys.Commands;
using HotelsRegistry.Application.Feature.RoomHierarchys.Dto;
using HotelsRegistry.Application.Feature.RoomTypes.Dto;
using HotelsRegistry.Domain.Entities;

namespace HotelsRegistry.Application.Feature.RoomHierarchys.Mappers
{
    public class RoomHierarchyMapProfile : Profile
    {
        public RoomHierarchyMapProfile()
        {
            CreateMap<RoomHierarchy, RoomHierarchyDto>()
            .ForMember(dest => dest.RoomTypeBase, opt => opt.MapFrom(src => src.RoomTypeBase))
            .ForMember(dest => dest.RoomTypeRelated, opt => opt.MapFrom(src => src.RoomTypeRelated))
            .ReverseMap();
            CreateMap<RoomHierarchy, CreateRoomHierarchyCmd>().ReverseMap();
            CreateMap<RoomHierarchy, UpdateRoomHierarchyCmd>().ReverseMap();
            CreateMap<RoomType, RoomTypeDto>().ReverseMap();
        }
    }
}
