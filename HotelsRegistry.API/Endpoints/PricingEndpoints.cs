using Common.Helper;
using HotelsRegistry.Application.Feature.Pricings.Commands;
using HotelsRegistry.Application.Feature.Pricings.Queries;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace HotelsRegistry.API.Endpoints
{
    public static class PricingEndpoints
    {
        public static void MapPricingsEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/Pricings");

            group.MapGet("/", GetAllPricings);
            group.MapPost("/", CreatePricing);
            group.MapPost("/Update", UpdatePricing);
            group.MapGet("/{id:guid}", GetPricingById);
            group.MapDelete("/{id:guid}", DeletePricing);

        }

        private static async Task<Results<Ok<Dictionary<string, dynamic>>, NotFound>> GetAllPricings([FromServices] IMediator mediator)
        {
            var pricings = 
            await HandleRequestHelper.HandleRequest(async () =>
            {
                var response = await mediator.Send(new GetAllPricingQuery());
                return (true, response);
            });
            return TypedResults.Ok(pricings);
        }

        private static async Task<Results<Ok<Dictionary<string, dynamic>>, BadRequest<string>>> CreatePricing(
            [FromBody] CreatePricingCmd cmd,
            [FromServices] IMediator mediator)
        {
            var result =
            await HandleRequestHelper.HandleRequest(async () =>
            {
                var response = await mediator.Send(cmd);
                return (true, response);
            });
            return TypedResults.Ok(result);
        }
        private static async Task<Results<Ok<Dictionary<string, dynamic>>, BadRequest<string>>> UpdatePricing(
           [FromBody] UpdatePricingCmd cmd,
           [FromServices] IMediator mediator)
        {
            var result =
           await HandleRequestHelper.HandleRequest(async () =>
           {
               var response = await mediator.Send(cmd);
               return (true, response);
           });
            return TypedResults.Ok(result);
        }
        private static async Task<Results<Ok<Dictionary<string, dynamic>>, BadRequest<string>>> DeletePricing(
          [FromBody] DeletePricingCmd cmd,
          [FromServices] IMediator mediator)
        {
            var result =
           await HandleRequestHelper.HandleRequest(async () =>
           {
               var response = await mediator.Send(cmd);
               return (true, response);
           });
            return TypedResults.Ok(result);
        }
        private static async Task<Results<Ok<Dictionary<string, dynamic>>, NotFound>> GetPricingById(
            Guid id,
            [FromServices] IMediator mediator)
        {
            var pricing = 

           await HandleRequestHelper.HandleRequest(async () =>
           {
               var response = await mediator.Send(new GetPricingByIdQuery(id));
               return (true, response);
           });
            return TypedResults.Ok(pricing);
        }
    }
}
