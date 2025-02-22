using HotelsRegistry.Application.Feature.RoomHierarchys.Commands;
using HotelsRegistry.Application.Feature.RoomHierarchys.Dto;
using HotelsRegistry.Application.Feature.RoomHierarchys.Mappers;
using HotelsRegistry.Application.Feature.RoomHierarchys.Queries;
using HotelsRegistry.Domain.AbstractRepository;
using HotelsRegistry.Domain.Entities;
using MediatR;

namespace HotelsRegistry.Application.Feature.RoomHierarchys.Handlers
{
    public class DeleteRoomHierarchyHandler : IRequestHandler<DeleteRoomHierarchyCmd,bool>
    {
        private readonly IRoomHierarchyRepository _roomHierarchyRepo;

        public DeleteRoomHierarchyHandler(IRoomHierarchyRepository roomHierarchyRepo)
        {
            _roomHierarchyRepo = roomHierarchyRepo;
        }

        public async Task<bool> Handle(DeleteRoomHierarchyCmd cmd, CancellationToken cancellationToken)
        {
            try
            {
                var exits = await _roomHierarchyRepo.ExistsAsync(cmd.Id);
                if (!exits)
                {
                    throw new ApplicationException("This roomHierarchy does not exist");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problem with context: " + ex.Message, ex);

            }
            try
            {
                var response = await _roomHierarchyRepo.DeleteAsync(cmd.Id);
                return response;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problem with retrieving data from context : " + ex.Message, ex);
            }
        }
    }
}
