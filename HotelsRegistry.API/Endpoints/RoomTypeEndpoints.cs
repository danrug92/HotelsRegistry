using Common.Helper;
using HotelsRegistry.Application.Feature.RoomTypes.Commands;
using HotelsRegistry.Application.Feature.RoomTypes.Dto;
using HotelsRegistry.Application.Feature.RoomTypes.Queries;
using HotelsRegistry.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace HotelsRegistry.API.Endpoints
{
    public static class RoomTypeEndpoints
    {
        public static void MapRoomTypesEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/RoomTypes");

            group.MapGet("/", GetAllRoomTypes);
            group.MapPost("/", CreateRoomType);
            group.MapPost("/Update", UpdateRoomType);
            group.MapGet("/{id:guid}", GetRoomTypeById);
            group.MapDelete("/{id:guid}", DeleteRoomType);

        }

        private static async Task<Results<Ok<Dictionary<string, dynamic>>, NotFound>> GetAllRoomTypes([FromServices] IMediator mediator)
        {
            var roomTypes = 
            await HandleRequestHelper.HandleRequest(async () =>
            {
                var response = await mediator.Send(new GetAllRoomTypeQuery());
                return (true, response);
            });
            return TypedResults.Ok(roomTypes);
        }

        private static async Task<Results<Ok<Dictionary<string, dynamic>>, BadRequest<string>>> CreateRoomType(
            [FromBody] CreateRoomTypeCmd cmd,
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
        private static async Task<Results<Ok<Dictionary<string, dynamic>>, BadRequest<string>>> UpdateRoomType(
           [FromBody] UpdateRoomTypeCmd cmd,
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
        private static async Task<Results<Ok<Dictionary<string, dynamic>>, BadRequest<string>>> DeleteRoomType(
          [FromBody] DeleteRoomTypeCmd cmd,
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
        private static async Task<Results<Ok<Dictionary<string, dynamic>>, NotFound>> GetRoomTypeById(
            Guid id,
            [FromServices] IMediator mediator)
        {
            var roomType = 
            await HandleRequestHelper.HandleRequest(async () =>
            {
                var response = await mediator.Send(new GetRoomTypeByIdQuery(id));
                return (true, response);
            });
            return TypedResults.Ok(roomType);
        }
    }
}
