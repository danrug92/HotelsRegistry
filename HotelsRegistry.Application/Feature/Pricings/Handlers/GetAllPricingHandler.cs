using HotelsRegistry.Application.Feature.Pricings.Dto;
using HotelsRegistry.Application.Feature.Pricings.Mappers;
using HotelsRegistry.Application.Feature.Pricings.Queries;
using HotelsRegistry.Domain.AbstractRepository;
using MediatR;

namespace HotelsRegistry.Application.Feature.Pricings.Handlers
{
    public class GetAllPricingHandler : IRequestHandler<GetAllPricingQuery,IEnumerable<PricingDto>>
    {
        private readonly IPricingRepository _pricingRepo;

        public GetAllPricingHandler(IPricingRepository pricingRepo)
        {
            _pricingRepo = pricingRepo;
        }

        public async Task<IEnumerable<PricingDto>> Handle(GetAllPricingQuery query, CancellationToken cancellationToken)
        {

            try
            {
                var pricingsList = _pricingRepo.GetAll().ToList();
                var responseList = PricingMapper.Mapper.Map<IEnumerable<PricingDto>>(pricingsList);
                return responseList;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problem with retrieving data from context : " + ex.Message, ex);
            }
        }
    }
}
