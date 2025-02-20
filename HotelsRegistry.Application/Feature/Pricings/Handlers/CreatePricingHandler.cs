using HotelsRegistry.Application.Feature.Pricings.Commands;
using HotelsRegistry.Application.Feature.Pricings.Mappers;
using HotelsRegistry.Domain.AbstractRepository;
using HotelsRegistry.Domain.Entities;
using MediatR;

namespace HotelsRegistry.Application.Feature.Pricings.Handlers
{
    public class CreatePricingHandler : IRequestHandler<CreatePricingCmd,bool>
    {
        private readonly IPricingRepository _pricingRepo;

        public CreatePricingHandler(IPricingRepository pricingRepo)
        {
            _pricingRepo = pricingRepo;
        }

        public async Task<bool> Handle(CreatePricingCmd cmd, CancellationToken cancellationToken)
        {
            var pricing = PricingMapper.Mapper.Map<Pricing>(cmd);

            if (pricing is null)
            {
                throw new ApplicationException("There is an issue with mapping while creating new pricing");

            }
            if (pricing.EndDate < pricing.StartDate)
            {
                throw new Exception("End date cannot be earlier than start date.");
            }
            try
            {
                await _pricingRepo.CreateAsync(pricing);
                await _pricingRepo.SaveAllAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problem with pricing creation: " + ex.Message, ex);
            }
        }
    }
}
