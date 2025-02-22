using Common.Helper;
using HotelsRegistry.Application.Feature.RoomHierarchys.Commands;
using HotelsRegistry.Application.Feature.RoomHierarchys.Dto;
using HotelsRegistry.Application.Feature.RoomHierarchys.Queries;
using HotelsRegistry.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace HotelsRegistry.API.Endpoints
{
    public static class RoomHierarchyEndpoints
    {
        public static void MapRoomHierarchysEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/RoomHierarchys");

            group.MapGet("/", GetAllRoomHierarchys);
            group.MapPost("/", CreateRoomHierarchy);
            group.MapPost("/Update", UpdateRoomHierarchy);
            group.MapGet("/{id:guid}", GetRoomHierarchyById);
            group.MapDelete("/{id:guid}", DeleteRoomHierarchy);

        }

        private static async Task<Results<Ok<Dictionary<string, dynamic>>, NotFound>> GetAllRoomHierarchys([FromServices] IMediator mediator)
        {
            var hirarchyList = 
            await HandleRequestHelper.HandleRequest(async () =>
            {
                var response = await mediator.Send(new GetAllRoomHierarchyQuery());
                return (true, response);
            });
            return TypedResults.Ok(hirarchyList);
        }

        private static async Task<Results<Ok<Dictionary<string, dynamic>>, BadRequest<string>>> CreateRoomHierarchy(
            [FromBody] CreateRoomHierarchyCmd cmd,
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
        private static async Task<Results<Ok<Dictionary<string, dynamic>>, BadRequest<string>>> UpdateRoomHierarchy(
           [FromBody] UpdateRoomHierarchyCmd cmd,
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
        private static async Task<Results<Ok<Dictionary<string, dynamic>>, BadRequest<string>>> DeleteRoomHierarchy(
          [FromBody] DeleteRoomHierarchyCmd cmd,
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
        private static async Task<Results<Ok<Dictionary<string, dynamic>>, NotFound>> GetRoomHierarchyById(
            Guid id,
            [FromServices] IMediator mediator)
        {
            var roomHirarchy =
            await HandleRequestHelper.HandleRequest(async () =>
            {
                var response = await mediator.Send(new GetRoomHierarchyByIdQuery(id));
                return (true, response);
            });
            return TypedResults.Ok(roomHirarchy);
        }
    }
}
