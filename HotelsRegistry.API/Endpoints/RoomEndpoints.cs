using Common.Helper;
using HotelsRegistry.Application.Feature.Rooms.Commands;
using HotelsRegistry.Application.Feature.Rooms.Dto;
using HotelsRegistry.Application.Feature.Rooms.Queries;
using HotelsRegistry.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace HotelsRegistry.API.Endpoints
{
    public static class RoomEndpoints
    {
        public static void MapRoomsEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/Rooms");

            group.MapGet("/", GetAllRooms);
            group.MapPost("/", CreateRoom);
            group.MapPost("/Update", UpdateRoom);
            group.MapGet("/{id:guid}", GetRoomById);
            group.MapDelete("/{id:guid}", DeleteRoomType);

        }

        private static async Task<Results<Ok<Dictionary<string, dynamic>>, NotFound>> GetAllRooms([FromServices] IMediator mediator)
        {
            var rooms = 
            await HandleRequestHelper.HandleRequest(async () =>
            {
                var response = await mediator.Send(new GetAllRoomQuery());
                return (true, response);
            });
            return TypedResults.Ok(rooms);
        }

        private static async Task<Results<Ok<Dictionary<string, dynamic>>, BadRequest<string>>> CreateRoom(
            [FromBody] CreateRoomCmd cmd,
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
        private static async Task<Results<Ok<Dictionary<string, dynamic>>, BadRequest<string>>> UpdateRoom(
           [FromBody] UpdateRoomCmd cmd,
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
          [FromBody] DeleteRoomCmd cmd,
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
        private static async Task<Results<Ok<Dictionary<string, dynamic>>, NotFound>> GetRoomById(
            Guid id,
            [FromServices] IMediator mediator)
        {

            var room =
            await HandleRequestHelper.HandleRequest(async () =>
            {
                var response = await mediator.Send(new GetRoomByIdQuery(id));
                return (true, response);
            });
            return TypedResults.Ok(room);
        }
    }
}
