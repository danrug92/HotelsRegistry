using Common.Helper;
using HotelsRegistry.Application.Feature.Pricings.Commands;
using HotelsRegistry.Application.Feature.Pricings.Queries;
using Microsoft.AspNetCore.Mvc;

namespace HotelsRegistry.API.Controllers.v1
{
    [ApiVersion("1.0")]
    public class PricingsController : BaseApiController
    {

        [HttpGet]
        [Route("GetAllPricing")]

        public async Task<IActionResult> GetAllPricing()
        {
            return await HandleRequestHelper.HandleRequest(async () =>
            {
                var response = await Mediator.Send(new GetAllPricingQuery());
                return (true, response);
            });
        }

        [HttpGet]
        [Route("[action]/{id}", Name = "GetPricing")]
        public async Task<IActionResult> GetAllUsersByRole(Guid id)
        {
            var query = new GetPricingByIdQuery(id);
            return await HandleRequestHelper.HandleRequest(async () =>
            {
                var response = await Mediator.Send(new GetPricingByIdQuery(id));
                return (true, response);
            });
        }

        [HttpPost]
        [Route("CreatePricing")]
        public async Task<IActionResult> CreatePricing(CreatePricingCmd cmd)
        {
            return await HandleRequestHelper.HandleRequest(async () =>
            {
                var response = await Mediator.Send(cmd);
                return (true, response);
            });
        }
        [HttpPut]
        [Route("UpdatePricing")]
        public async Task<IActionResult> UpdatePricing(UpdatePricingCmd cmd)
        {
            return await HandleRequestHelper.HandleRequest(async () =>
            {
                var response = await Mediator.Send(cmd);
                return (true, response);
            });
        }
        [HttpDelete]
        [Route("DeletePricing")]
        public async Task<IActionResult> DeletePricing(DeletePricingCmd cmd)
        {
            return await HandleRequestHelper.HandleRequest(async () =>
            {
                var response = await Mediator.Send(cmd);
                return (true, response);
            });
        }
    }
}
