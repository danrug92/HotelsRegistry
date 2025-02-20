using HotelsRegistry.Application.Feature.Pricings.Commands;
using HotelsRegistry.Application.Feature.Pricings.Dto;
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

        private static async Task<Results<Ok<IEnumerable<PricingDto>>, NotFound>> GetAllPricings([FromServices] IMediator mediator)
        {
            var pricings = await mediator.Send(new GetAllPricingQuery());
            return pricings.Any() ? TypedResults.Ok(pricings) : TypedResults.NotFound();
        }

        private static async Task<Results<Created<bool>, BadRequest<string>>> CreatePricing(
            [FromBody] CreatePricingCmd cmd,
            [FromServices] IMediator mediator)
        {
            var result = await mediator.Send(cmd);
            return result != null ? TypedResults.Created($"/Pricings/Created", result) : TypedResults.BadRequest("Error to create pricing.");
        }
        private static async Task<Results<Created<bool>, BadRequest<string>>> UpdatePricing(
           [FromBody] UpdatePricingCmd cmd,
           [FromServices] IMediator mediator)
        {
            var result = await mediator.Send(cmd);
            return result != null ? TypedResults.Created($"/Pricings/Updated", result) : TypedResults.BadRequest("Error to update pricing.");
        }
        private static async Task<Results<Created<bool>, BadRequest<string>>> DeletePricing(
          [FromBody] DeletePricingCmd cmd,
          [FromServices] IMediator mediator)
        {
            var result = await mediator.Send(cmd);
            return result != null ? TypedResults.Created($"/Pricings/Deleted", result) : TypedResults.BadRequest("Error to delete pricing.");
        }
        private static async Task<Results<Ok<PricingDto>, NotFound>> GetPricingById(
            Guid id,
            [FromServices] IMediator mediator)
        {
            var pricing = await mediator.Send(new GetPricingByIdQuery(id));
            return pricing != null ? TypedResults.Ok(pricing) : TypedResults.NotFound();
        }
    }
}
