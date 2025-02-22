using Azure;
using Common.Helper;
using HotelsRegistry.Application.Feature.Accommodations.Commands;
using HotelsRegistry.Application.Feature.Accommodations.Dto;
using HotelsRegistry.Application.Feature.Accommodations.Queries;
using HotelsRegistry.Domain.Entities;
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

        private static async Task<Results<Ok<Dictionary<string, dynamic>>, NotFound>> GetAllAccommodations([FromServices] IMediator mediator)
        {
            var accommodations = 
            await HandleRequestHelper.HandleRequest(async () =>
            {
                var response = await mediator.Send(new GetAllAccommodationQuery());
                return (true, response);
            });
            return TypedResults.Ok(accommodations);
        }

        private static async Task<Results<Ok<Dictionary<string, dynamic>>, BadRequest<string>>> CreateAccommodation(
            [FromBody] CreateAccommodationCmd cmd,
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
        private static async Task<Results<Ok<Dictionary<string, dynamic>>, BadRequest<string>>> UpdateAccommodation(
           [FromBody] UpdateAccommodationCmd cmd,
           [FromServices] IMediator mediator)
        {
            var result = 
            await HandleRequestHelper.HandleRequest(async () =>
            {
                var response = await mediator.Send(cmd);
                return (true, response);
            });
            return TypedResults.Ok(result); ;
        }
        private static async Task<Results<Ok<Dictionary<string, dynamic>>, BadRequest<string>>> DeleteAccommodation(
          [FromBody] DeleteAccommodationCmd cmd,
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
        private static async Task<Results<Ok<Dictionary<string, dynamic>>, NotFound>> GetAccommodationById(
            Guid id,
            [FromServices] IMediator mediator)
        {
            var accommodation = 
            await HandleRequestHelper.HandleRequest(async () =>
            {
                var response = await mediator.Send(new GetAccommodationByIdQuery(id));
                return (true, response);
            });
            return TypedResults.Ok(accommodation);
        }
    }
}
