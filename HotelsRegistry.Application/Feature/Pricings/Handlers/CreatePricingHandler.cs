using HotelsRegistry.Application.Feature.Pricings.Commands;
using HotelsRegistry.Application.Feature.Pricings.Mappers;
using HotelsRegistry.Domain.AbstractRepository;
using HotelsRegistry.Domain.Entities;
using MediatR;

namespace HotelsRegistry.Application.Feature.Pricings.Handlers
{
    public class CreatePricingHandler : IRequestHandler<CreatePricingCmd,bool>
    {
        private readonly IPricingRepository _accomodationRepo;

        public CreatePricingHandler(IPricingRepository PricingRepo)
        {
            _accomodationRepo = PricingRepo;
        }

        public async Task<bool> Handle(CreatePricingCmd cmd, CancellationToken cancellationToken)
        {
            var Pricing = PricingMapper.Mapper.Map<Pricing>(cmd);

            if (Pricing is null)
            {
                throw new ApplicationException("There is an issue with mapping while creating new Pricing");

            }

            try
            {
                await _accomodationRepo.CreateAsync(Pricing);
                await _accomodationRepo.SaveAllAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problem with Pricing creation: " + ex.Message, ex);
            }
        }
    }
}
