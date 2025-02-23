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
        private readonly IRoomHierarchyRepository _roomHierarchyRepo;
        public CreatePricingHandler(IPricingRepository pricingRepo, IRoomTypeRepository roomTypeRepo, IRoomHierarchyRepository hierarchyRepo)
        {
            _pricingRepo = pricingRepo;
            _roomTypeRepo = roomTypeRepo;
            _roomHierarchyRepo = hierarchyRepo;
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

            var roomType = await _roomTypeRepo.GetByIdAsync(cmd.RoomTypeId);
            if (roomType == null)
            {
                throw new ApplicationException("Room type does not exist");
            }

            var hierarchy = await _roomHierarchyRepo.GetByRelatedRoomTypeIdAsync(cmd.RoomTypeId);
            if (hierarchy != null)
            {
                var basePricing = await _pricingRepo.GetLatestPricingAsync(hierarchy.RoomTypeBaseId);
                if (basePricing != null)
                {
                    var minAllowedPrice = basePricing.Price * (1 + hierarchy.PercentageIncrease / 100);
                    if (cmd.Price < minAllowedPrice)
                    {
                        throw new ApplicationException($"The price for this room type must be at least {minAllowedPrice} based on the hierarchy rules.");
                    }
                }
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
