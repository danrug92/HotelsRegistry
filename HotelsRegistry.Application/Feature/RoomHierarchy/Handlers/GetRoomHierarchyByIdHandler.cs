using HotelsRegistry.Application.Feature.RoomHierarchys.Dto;
using HotelsRegistry.Application.Feature.RoomHierarchys.Mappers;
using HotelsRegistry.Application.Feature.RoomHierarchys.Queries;
using HotelsRegistry.Domain.AbstractRepository;
using MediatR;

namespace HotelsRegistry.Application.Feature.RoomHierarchys.Handlers
{
    public class GetRoomHierarchyByIdHandler : IRequestHandler<GetRoomHierarchyByIdQuery,RoomHierarchyDto>
    {
        private readonly IRoomHierarchyRepository _roomHierarchyRepo;

        public GetRoomHierarchyByIdHandler(IRoomHierarchyRepository roomHierarchyRepo)
        {
            _roomHierarchyRepo = roomHierarchyRepo;
        }

        public async Task<RoomHierarchyDto> Handle(GetRoomHierarchyByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var roomHierarchy = _roomHierarchyRepo.GetHierarchyWithRoomTypeDataAsync(query.Id);
                var response = RoomHierarchyMapper.Mapper.Map<RoomHierarchyDto>(roomHierarchy);
                return response;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problem with retrieving data from context : " + ex.Message, ex);
            }
        }
    }
}
