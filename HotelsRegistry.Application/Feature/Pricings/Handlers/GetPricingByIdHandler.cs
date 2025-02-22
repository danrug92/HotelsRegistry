using HotelsRegistry.Application.Feature.Pricings.Dto;
using HotelsRegistry.Application.Feature.Pricings.Mappers;
using HotelsRegistry.Application.Feature.Pricings.Queries;
using HotelsRegistry.Domain.AbstractRepository;
using MediatR;

namespace HotelsRegistry.Application.Feature.Pricings.Handlers
{
    public class GetPricingByIdHandler : IRequestHandler<GetPricingByIdQuery,PricingDto>
    {
        private readonly IPricingRepository _pricingRepo;

        public GetPricingByIdHandler(IPricingRepository pricingRepo)
        {
            _pricingRepo = pricingRepo;
        }

        public async Task<PricingDto> Handle(GetPricingByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var pricing = await _pricingRepo.GetPricingWithRoomTypeDataAsync(query.Id);
                var response = PricingMapper.Mapper.Map<PricingDto>(pricing);
                return response;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problem with retrieving data from context : " + ex.Message, ex);
            }
        }
    }
}
