using AutoMapper;
using HotelsRegistry.Application.Feature.RoomTypes.Commands;
using HotelsRegistry.Application.Feature.RoomTypes.Dto;
using HotelsRegistry.Domain.Entities;

namespace HotelsRegistry.Application.Feature.RoomTypes.Mappers
{
    public class RoomTypeMapProfile : Profile
    {
        public RoomTypeMapProfile()
        {
            
            CreateMap<RoomType, RoomTypeDto>().ReverseMap();
            CreateMap<RoomType, CreateRoomTypeCmd>().ReverseMap();
            CreateMap<RoomType, UpdateRoomTypeCmd>().ReverseMap();
        }
    }
}
