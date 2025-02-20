using MediatR;

namespace HotelsRegistry.Application.Feature.Accommodations.Commands
{
    public  class DeleteAccommodationCmd : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
