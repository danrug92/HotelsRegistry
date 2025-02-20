using HotelsRegistry.Application.Feature.Pricings.Commands;
using HotelsRegistry.Application.Feature.Pricings.Dto;
using HotelsRegistry.Application.Feature.Pricings.Mappers;
using HotelsRegistry.Application.Feature.Pricings.Queries;
using HotelsRegistry.Domain.AbstractRepository;
using HotelsRegistry.Domain.Entities;
using MediatR;

namespace HotelsRegistry.Application.Feature.Pricings.Handlers
{
    public class DeletePricingHandler : IRequestHandler<DeletePricingCmd,bool>
    {
        private readonly IPricingRepository _pricingRepo;

        public DeletePricingHandler(IPricingRepository pricingRepo)
        {
            _pricingRepo = pricingRepo;
        }

        public async Task<bool> Handle(DeletePricingCmd cmd, CancellationToken cancellationToken)
        {
            try
            {
                var exits = await _pricingRepo.ExistsAsync(cmd.Id);
                if (!exits)
                {
                    throw new Exception("This pricing does not exist");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problem with context: " + ex.Message, ex);

            }
            try
            {
                var response = await _pricingRepo.DeleteAsync(cmd.Id);
                return response;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problem with retrieving data from context : " + ex.Message, ex);
            }
        }
    }
}
