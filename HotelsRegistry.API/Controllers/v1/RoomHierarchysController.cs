using Common.Helper;
using HotelsRegistry.Application.Feature.RoomHierarchys.Commands;
using HotelsRegistry.Application.Feature.RoomHierarchys.Queries;
using Microsoft.AspNetCore.Mvc;

namespace HotelsRegistry.API.Controllers.v1
{
    [ApiVersion("1.0")]
    public class RoomHierarchysController : BaseApiController
    {

        [HttpGet]
        [Route("GetAllRoomHierarchy")]

        public async Task<IActionResult> GetAllRoomHierarchy()
        {
            return await HandleRequestHelper.HandleRequest(async () =>
            {
                var response = await Mediator.Send(new GetAllRoomHierarchyQuery());
                return (true, response);
            });
        }

        [HttpGet]
        [Route("[action]/{id}", Name = "GetRoomHierarchy")]
        public async Task<IActionResult> GetAllUsersByRole(Guid id)
        {
            var query = new GetRoomHierarchyByIdQuery(id);
            return await HandleRequestHelper.HandleRequest(async () =>
            {
                var response = await Mediator.Send(new GetRoomHierarchyByIdQuery(id));
                return (true, response);
            });
        }

        [HttpPost]
        [Route("CreateRoomHierarchy")]
        public async Task<IActionResult> CreateRoomHierarchy(CreateRoomHierarchyCmd cmd)
        {
            return await HandleRequestHelper.HandleRequest(async () =>
            {
                var response = await Mediator.Send(cmd);
                return (true, response);
            });
        }
        [HttpPut]
        [Route("UpdateRoomHierarchy")]
        public async Task<IActionResult> UpdateRoomHierarchy(UpdateRoomHierarchyCmd cmd)
        {
            return await HandleRequestHelper.HandleRequest(async () =>
            {
                var response = await Mediator.Send(cmd);
                return (true, response);
            });
        }
        [HttpDelete]
        [Route("DeleteRoomHierarchy")]
        public async Task<IActionResult> DeleteRoomHierarchy(DeleteRoomHierarchyCmd cmd)
        {
            return await HandleRequestHelper.HandleRequest(async () =>
            {
                var response = await Mediator.Send(cmd);
                return (true, response);
            });
        }
    }
}
