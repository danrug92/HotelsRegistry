using HotelsRegistry.Application.Feature.Pricings.Commands;
using HotelsRegistry.Application.Feature.Pricings.Mappers;
using HotelsRegistry.Domain.AbstractRepository;
using HotelsRegistry.Domain.Entities;
using MediatR;

namespace HotelsRegistry.Application.Feature.Pricings.Handlers
{
    public class UpdatePricingHandler : IRequestHandler<UpdatePricingCmd,bool>
    {
        private readonly IPricingRepository _accomodationRepo;

        public UpdatePricingHandler(IPricingRepository PricingRepo)
        {
            _accomodationRepo = PricingRepo;
        }

        public async Task<bool> Handle(UpdatePricingCmd cmd, CancellationToken cancellationToken)
        {
            var Pricing = PricingMapper.Mapper.Map<Pricing>(cmd);


            if (Pricing is null)
            {
                throw new ApplicationException("There is an issue with mapping while creating new Pricing");

            }
            try
            {
                var exits = await _accomodationRepo.ExistsAsync(Pricing.Id);
                if(!exits)
                {
                    throw new Exception("This Pricing does not exist");
                }
            }
            catch(Exception ex)
            {
                throw new ApplicationException("Problem with context: " + ex.Message, ex);

            }
            try
            {
                await _accomodationRepo.UpdateAsync(Pricing);
                await _accomodationRepo.SaveAllAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problem with Pricing update: " + ex.Message, ex);
            }
        }
    }
}
