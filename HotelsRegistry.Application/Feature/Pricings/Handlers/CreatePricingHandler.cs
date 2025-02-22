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
        private readonly IRoomTypeRepository _roomTypeRepo;
        public CreatePricingHandler(IPricingRepository pricingRepo, IRoomTypeRepository roomTypeRepo)
        {
            _pricingRepo = pricingRepo;
            _roomTypeRepo = roomTypeRepo;
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
                if (!await _roomTypeRepo.ExistsAsync(cmd.RoomTypeId))
                {
                    throw new ApplicationException("Room type don't exist");
                }
            }
            catch
            {
                throw new ApplicationException("Problem with data context");

            }
            try
            {
                pricing.Id = Guid.NewGuid();
                pricing.CreateAt = DateTime.UtcNow;
                pricing.UpdateAt = DateTime.UtcNow;
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
