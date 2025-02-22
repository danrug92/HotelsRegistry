using AutoMapper;
using HotelsRegistry.Application.Feature.Rooms.Commands;
using HotelsRegistry.Application.Feature.Rooms.Dto;
using HotelsRegistry.Application.Feature.RoomTypes.Dto;
using HotelsRegistry.Domain.Entities;

namespace HotelsRegistry.Application.Feature.Rooms.Mappers
{
    public class RoomMapProfile : Profile
    {
        public RoomMapProfile()
        {
            
            CreateMap<Room, RoomDto>()
            .ForMember(dest => dest.RoomType, opt => opt.MapFrom(src => src.RoomType))
            .ReverseMap();
            CreateMap<RoomType, RoomTypeDto>().ReverseMap();
            CreateMap<Room, RoomDto>().ReverseMap();
            CreateMap<Room, CreateRoomCmd>().ReverseMap();
            CreateMap<Room, UpdateRoomCmd>().ReverseMap();
        }
    }
}
