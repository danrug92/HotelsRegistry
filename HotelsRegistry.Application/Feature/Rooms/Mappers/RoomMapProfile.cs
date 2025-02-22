using AutoMapper;
using HotelsRegistry.Application.Feature.Rooms.Commands;
using HotelsRegistry.Application.Feature.Rooms.Dto;
using HotelsRegistry.Domain.Entities;

namespace HotelsRegistry.Application.Feature.Rooms.Mappers
{
    public class RoomMapProfile : Profile
    {
        public RoomMapProfile()
        {
            
            CreateMap<Room, RoomDto>().ReverseMap();
            CreateMap<Room, CreateRoomCmd>().ReverseMap();
            CreateMap<Room, UpdateRoomCmd>().ReverseMap();
        }
    }
}
