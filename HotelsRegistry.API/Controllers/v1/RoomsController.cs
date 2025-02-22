using Common.Helper;
using HotelsRegistry.Application.Feature.Rooms.Commands;
using HotelsRegistry.Application.Feature.Rooms.Queries;
using Microsoft.AspNetCore.Mvc;

namespace HotelsRegistry.API.Controllers.v1
{
    [ApiVersion("1.0")]
    public class RoomsController : BaseApiController
    {

        [HttpGet]
        [Route("GetAllRoom")]

        public async Task<IActionResult> GetAllRoom()
        {
            return await HandleRequestHelper.HandleRequest(async () =>
            {
                var response = await Mediator.Send(new GetAllRoomQuery());
                return (true, response);
            });
        }

        [HttpGet]
        [Route("[action]/{id}", Name = "GetRoom")]
        public async Task<IActionResult> GetAllUsersByRole(Guid id)
        {
            var query = new GetRoomByIdQuery(id);
            return await HandleRequestHelper.HandleRequest(async () =>
            {
                var response = await Mediator.Send(new GetRoomByIdQuery(id));
                return (true, response);
            });
        }

        [HttpPost]
        [Route("CreateRoom")]
        public async Task<IActionResult> CreateRoom(CreateRoomCmd cmd)
        {
            return await HandleRequestHelper.HandleRequest(async () =>
            {
                var response = await Mediator.Send(cmd);
                return (true, response);
            });
        }
        [HttpPut]
        [Route("UpdateRoom")]
        public async Task<IActionResult> UpdateRoom(UpdateRoomCmd cmd)
        {
            return await HandleRequestHelper.HandleRequest(async () =>
            {
                var response = await Mediator.Send(cmd);
                return (true, response);
            });
        }
        [HttpDelete]
        [Route("DeleteRoom")]
        public async Task<IActionResult> DeleteRoom(DeleteRoomCmd cmd)
        {
            return await HandleRequestHelper.HandleRequest(async () =>
            {
                var response = await Mediator.Send(cmd);
                return (true, response);
            });
        }
    }
}
