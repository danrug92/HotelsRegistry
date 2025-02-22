using Common.Helper;
using HotelsRegistry.Application.Feature.RoomTypes.Commands;
using HotelsRegistry.Application.Feature.RoomTypes.Queries;
using Microsoft.AspNetCore.Mvc;

namespace HotelsRegistry.API.Controllers.v1
{
    [ApiVersion("1.0")]
    public class RoomTypesController : BaseApiController
    {

        [HttpGet]
        [Route("GetAllRoomType")]

        public async Task<IActionResult> GetAllRoomType()
        {
            return await HandleRequestHelper.HandleRequest(async () =>
            {
                var response = await Mediator.Send(new GetAllRoomTypeQuery());
                return (true, response);
            });
        }

        [HttpGet]
        [Route("[action]/{id}", Name = "GetRoomType")]
        public async Task<IActionResult> GetAllUsersByRole(Guid id)
        {
            var query = new GetRoomTypeByIdQuery(id);
            return await HandleRequestHelper.HandleRequest(async () =>
            {
                var response = await Mediator.Send(new GetRoomTypeByIdQuery(id));
                return (true, response);
            });
        }

        [HttpPost]
        [Route("CreateRoomType")]
        public async Task<IActionResult> CreateRoomType(CreateRoomTypeCmd cmd)
        {
            return await HandleRequestHelper.HandleRequest(async () =>
            {
                var response = await Mediator.Send(cmd);
                return (true, response);
            });
        }
        [HttpPut]
        [Route("UpdateRoomType")]
        public async Task<IActionResult> UpdateRoomType(UpdateRoomTypeCmd cmd)
        {
            return await HandleRequestHelper.HandleRequest(async () =>
            {
                var response = await Mediator.Send(cmd);
                return (true, response);
            });
        }
        [HttpDelete]
        [Route("DeleteRoomType")]
        public async Task<IActionResult> DeleteRoomType(DeleteRoomTypeCmd cmd)
        {
            return await HandleRequestHelper.HandleRequest(async () =>
            {
                var response = await Mediator.Send(cmd);
                return (true, response);
            });
        }
    }
}
