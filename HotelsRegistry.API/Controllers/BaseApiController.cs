using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelsRegistry.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
        private IMediator? imediator;

        protected IMediator Mediator => this.imediator ??= this.HttpContext.RequestServices.GetService<IMediator>()!;
    }
}
