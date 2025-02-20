using HotelsRegistry.Application.Feature.Accommodations.Commands;
using HotelsRegistry.Application.Feature.Accommodations.Dto;
using HotelsRegistry.Application.Feature.Accommodations.Queries;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace HotelsRegistry.API.Endpoints
{
    public static class AccommodationEndpoints
    {
        public static void MapAccommodationsEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/Accommodations");

            group.MapGet("/", GetAllAccommodations);
            group.MapPost("/", CreateAccommodation);
            group.MapPost("/Update", UpdateAccommodation);
            group.MapGet("/{id:guid}", GetAccommodationById);
            group.MapDelete("/{id:guid}", DeleteAccommodation);

        }

        private static async Task<Results<Ok<IEnumerable<AccommodationDto>>, NotFound>> GetAllAccommodations([FromServices] IMediator mediator)
        {
            var accommodations = await mediator.Send(new GetAllAccommodationQuery());
            return accommodations.Any() ? TypedResults.Ok(accommodations) : TypedResults.NotFound();
        }

        private static async Task<Results<Created<bool>, BadRequest<string>>> CreateAccommodation(
            [FromBody] CreateAccommodationCmd cmd,
            [FromServices] IMediator mediator)
        {
            var result = await mediator.Send(cmd);
            return result != null ? TypedResults.Created($"/Accommodations/Created", result) : TypedResults.BadRequest("Error to create accommodation.");
        }
        private static async Task<Results<Created<bool>, BadRequest<string>>> UpdateAccommodation(
           [FromBody] UpdateAccommodationCmd cmd,
           [FromServices] IMediator mediator)
        {
            var result = await mediator.Send(cmd);
            return result != null ? TypedResults.Created($"/Accommodations/Updated", result) : TypedResults.BadRequest("Error to update accommodation.");
        }
        private static async Task<Results<Created<bool>, BadRequest<string>>> DeleteAccommodation(
          [FromBody] DeleteAccommodationCmd cmd,
          [FromServices] IMediator mediator)
        {
            var result = await mediator.Send(cmd);
            return result != null ? TypedResults.Created($"/Accommodations/Deleted", result) : TypedResults.BadRequest("Error to delete accommodation.");
        }
        private static async Task<Results<Ok<AccommodationDto>, NotFound>> GetAccommodationById(
            Guid id,
            [FromServices] IMediator mediator)
        {
            var accommodation = await mediator.Send(new GetAccommodationByIdQuery(id));
            return accommodation != null ? TypedResults.Ok(accommodation) : TypedResults.NotFound();
        }
    }
}
