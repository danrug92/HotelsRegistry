using MediatR;

namespace HotelsRegistry.Application.Feature.Pricings.Commands
{
    public  class DeletePricingCmd : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
