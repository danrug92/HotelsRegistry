using HotelsRegistry.Application.Feature.RoomHierarchys.Commands;
using HotelsRegistry.Application.Feature.RoomHierarchys.Mappers;
using HotelsRegistry.Domain.AbstractRepository;
using HotelsRegistry.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HotelsRegistry.Application.Feature.RoomHierarchys.Handlers
{
    public class UpdateRoomHierarchyHandler : IRequestHandler<UpdateRoomHierarchyCmd,bool>
    {
        private readonly IRoomHierarchyRepository _roomHierarchyRepo;

        public UpdateRoomHierarchyHandler(IRoomHierarchyRepository roomHierarchyRepo)
        {
            _roomHierarchyRepo = roomHierarchyRepo;
        }

        public async Task<bool> Handle(UpdateRoomHierarchyCmd cmd, CancellationToken cancellationToken)
        {
            var roomHierarchy = RoomHierarchyMapper.Mapper.Map<RoomHierarchy>(cmd);


            if (roomHierarchy is null)
            {
                throw new ApplicationException("There is an issue with mapping while creating new RoomHierarchy");

            }

            var roomHierarchysExist = await _roomHierarchyRepo.GetHierarchyWithRoomTypeDataAsync(roomHierarchy.Id);
            if (roomHierarchysExist == null)
            {
                throw new Exception("This roomHierarchy does not exist");
            }
            if (roomHierarchysExist.RoomTypeBase == null || roomHierarchysExist.RoomTypeRelated == null)
            {
                throw new ApplicationException("This hierarchy does not have a valid room type");
            }
            try
            {
                roomHierarchy.CreateAt = roomHierarchysExist.CreateAt;
                roomHierarchy.UpdateAt = DateTime.UtcNow;
                await _roomHierarchyRepo.UpdateAsync(roomHierarchy);
                await _roomHierarchyRepo.SaveAllAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problem with RoomHierarchy update: " + ex.Message, ex);
            }
        }
    }
}
