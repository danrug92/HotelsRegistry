using HotelsRegistry.Application.Feature.RoomTypes.Commands;
using HotelsRegistry.Application.Feature.RoomTypes.Dto;
using HotelsRegistry.Application.Feature.RoomTypes.Mappers;
using HotelsRegistry.Application.Feature.RoomTypes.Queries;
using HotelsRegistry.Domain.AbstractRepository;
using HotelsRegistry.Domain.Entities;
using MediatR;

namespace HotelsRegistry.Application.Feature.RoomTypes.Handlers
{
    public class DeleteRoomTypeHandler : IRequestHandler<DeleteRoomTypeCmd,bool>
    {
        private readonly IRoomTypeRepository _roomTypeRepo;

        public DeleteRoomTypeHandler(IRoomTypeRepository roomTypeRepo)
        {
            _roomTypeRepo = roomTypeRepo;
        }

        public async Task<bool> Handle(DeleteRoomTypeCmd cmd, CancellationToken cancellationToken)
        {
            try
            {
                var exits = await _roomTypeRepo.ExistsAsync(cmd.Id);
                if (!exits)
                {
                    throw new Exception("This roomType does not exist");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problem with context: " + ex.Message, ex);

            }
            try
            {
                var response = await _roomTypeRepo.DeleteAsync(cmd.Id);
                return response;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problem with retrieving data from context : " + ex.Message, ex);
            }
        }
    }
}
