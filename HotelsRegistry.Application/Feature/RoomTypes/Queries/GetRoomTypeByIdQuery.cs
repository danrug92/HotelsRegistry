
using HotelsRegistry.Application.Feature.RoomTypes.Dto;
using MediatR;

namespace HotelsRegistry.Application.Feature.RoomTypes.Queries
{
    public class GetRoomTypeByIdQuery : IRequest<RoomTypeDto>
    {
        public Guid Id { get; set; }
        public GetRoomTypeByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
