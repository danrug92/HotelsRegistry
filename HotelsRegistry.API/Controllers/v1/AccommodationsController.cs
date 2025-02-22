using Common.Helper;
using HotelsRegistry.Application.Feature.Accommodations.Commands;
using HotelsRegistry.Application.Feature.Accommodations.Queries;
using Microsoft.AspNetCore.Mvc;

namespace HotelsRegistry.API.Controllers.v1
{
    [ApiVersion("1.0")]
    public class AccommodationsController : BaseApiController
    {

        [HttpGet]
        [Route("GetAllAccommodation")]

        public async Task<IActionResult> GetAllAccommodation()
        {
            return await HandleRequestHelper.HandleRequest(async () =>
            {
                var response = await Mediator.Send(new GetAllAccommodationQuery());
                return (true, response);
            });
        }

        [HttpGet]
        [Route("[action]/{id}", Name = "GetAccommodation")]
        public async Task<IActionResult> GetAccommodation(Guid id)
        {
            var query = new GetAccommodationByIdQuery(id);
            return await HandleRequestHelper.HandleRequest(async () =>
            {
                var response = await Mediator.Send(new GetAccommodationByIdQuery(id));
                return (true, response);
            });
        }

        [HttpPost]
        [Route("CreateAccommodation")]
        public async Task<IActionResult> CreateAccommodation(CreateAccommodationCmd cmd)
        {
            return await HandleRequestHelper.HandleRequest(async () =>
            {
                var response = await Mediator.Send(cmd);
                return (true, response);
            });
        }
        [HttpPut]
        [Route("UpdateAccommodation")]
        public async Task<IActionResult> UpdateAccommodation(UpdateAccommodationCmd cmd)
        {
            return await HandleRequestHelper.HandleRequest(async () =>
            {
                var response = await Mediator.Send(cmd);
                return (true, response);
            });
        }
        [HttpDelete]
        [Route("DeleteAccommodation")]
        public async Task<IActionResult> DeleteAccommodation(DeleteAccommodationCmd cmd)
        {
            return await HandleRequestHelper.HandleRequest(async () =>
            {
                var response = await Mediator.Send(cmd);
                return (true, response);
            });
        }
    }
}
