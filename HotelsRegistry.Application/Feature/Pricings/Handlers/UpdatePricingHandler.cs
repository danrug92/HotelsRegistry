using HotelsRegistry.Application.Feature.Pricings.Commands;
using HotelsRegistry.Application.Feature.Pricings.Mappers;
using HotelsRegistry.Domain.AbstractRepository;
using HotelsRegistry.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HotelsRegistry.Application.Feature.Pricings.Handlers
{
    public class UpdatePricingHandler : IRequestHandler<UpdatePricingCmd,bool>
    {
        private readonly IPricingRepository _pricingRepo;

        public UpdatePricingHandler(IPricingRepository pricingRepo)
        {
            _pricingRepo = pricingRepo;
        }

        public async Task<bool> Handle(UpdatePricingCmd cmd, CancellationToken cancellationToken)
        {
            var pricing = PricingMapper.Mapper.Map<Pricing>(cmd);


            if (pricing is null)
            {
                throw new ApplicationException("There is an issue with mapping while creating new Pricing");

            }
           
                var pricingsExist = await _pricingRepo.GetByIdAsync(pricing.Id);
                if(pricingsExist == null)
                {
                    throw new Exception("This pricing does not exist");
                }
            
           
            if (pricing.EndDate < pricing.StartDate)
            {
                throw new Exception("End date cannot be earlier than start date.");
            }
            try
            {
                pricing.CreateAt = pricingsExist.CreateAt;
                pricing.UpdateAt = DateTime.UtcNow;
                await _pricingRepo.UpdateAsync(pricing);
                await _pricingRepo.SaveAllAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problem with Pricing update: " + ex.Message, ex);
            }
        }
    }
}
