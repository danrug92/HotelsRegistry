using AutoMapper;
using HotelsRegistry.Application.Feature.RoomHierarchys.Commands;
using HotelsRegistry.Application.Feature.RoomHierarchys.Dto;
using HotelsRegistry.Domain.Entities;

namespace HotelsRegistry.Application.Feature.RoomHierarchys.Mappers
{
    public class RoomHierarchyMapProfile : Profile
    {
        public RoomHierarchyMapProfile()
        {
            
            CreateMap<RoomHierarchy, RoomHierarchyDto>().ReverseMap();
            CreateMap<RoomHierarchy, CreateRoomHierarchyCmd>().ReverseMap();
            CreateMap<RoomHierarchy, UpdateRoomHierarchyCmd>().ReverseMap();
        }
    }
}
