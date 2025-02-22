using HotelsRegistry.Application.Feature.RoomHierarchys.Dto;
using HotelsRegistry.Application.Feature.RoomHierarchys.Mappers;
using HotelsRegistry.Application.Feature.RoomHierarchys.Queries;
using HotelsRegistry.Domain.AbstractRepository;
using MediatR;

namespace HotelsRegistry.Application.Feature.RoomHierarchys.Handlers
{
    public class GetAllRoomHierarchyHandler : IRequestHandler<GetAllRoomHierarchyQuery,IEnumerable<RoomHierarchyDto>>
    {
        private readonly IRoomHierarchyRepository _roomHierarchyRepo;

        public GetAllRoomHierarchyHandler(IRoomHierarchyRepository roomHierarchyRepo)
        {
            _roomHierarchyRepo = roomHierarchyRepo;
        }

        public async Task<IEnumerable<RoomHierarchyDto>> Handle(GetAllRoomHierarchyQuery query, CancellationToken cancellationToken)
        {

            try
            {
                var roomHierarchysList = _roomHierarchyRepo.GetAllWithRoomTypeData().ToList();
                var responseList = RoomHierarchyMapper.Mapper.Map<IEnumerable<RoomHierarchyDto>>(roomHierarchysList);
                return responseList;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problem with retrieving data from context : " + ex.Message, ex);
            }
        }
    }
}
