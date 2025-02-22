using HotelsRegistry.Application.Feature.Rooms.Commands;
using HotelsRegistry.Application.Feature.Rooms.Dto;
using HotelsRegistry.Application.Feature.Rooms.Mappers;
using HotelsRegistry.Application.Feature.Rooms.Queries;
using HotelsRegistry.Domain.AbstractRepository;
using HotelsRegistry.Domain.Entities;
using MediatR;

namespace HotelsRegistry.Application.Feature.Rooms.Handlers
{
    public class DeleteRoomHandler : IRequestHandler<DeleteRoomCmd,bool>
    {
        private readonly IRoomRepository _roomRepo;

        public DeleteRoomHandler(IRoomRepository roomRepo)
        {
            _roomRepo = roomRepo;
        }

        public async Task<bool> Handle(DeleteRoomCmd cmd, CancellationToken cancellationToken)
        {
            try
            {
                var exits = await _roomRepo.ExistsAsync(cmd.Id);
                if (!exits)
                {
                    throw new Exception("This room does not exist");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problem with context: " + ex.Message, ex);

            }
            try
            {
                var response = await _roomRepo.DeleteAsync(cmd.Id);
                return response;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problem with retrieving data from context : " + ex.Message, ex);
            }
        }
    }
}
