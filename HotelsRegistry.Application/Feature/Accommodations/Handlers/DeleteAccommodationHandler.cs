using HotelsRegistry.Application.Feature.Accommodations.Commands;
using HotelsRegistry.Application.Feature.Accommodations.Dto;
using HotelsRegistry.Application.Feature.Accommodations.Mappers;
using HotelsRegistry.Application.Feature.Accommodations.Queries;
using HotelsRegistry.Domain.AbstractRepository;
using HotelsRegistry.Domain.Entities;
using MediatR;

namespace HotelsRegistry.Application.Feature.Accommodations.Handlers
{
    public class DeleteAccommodationHandler : IRequestHandler<DeleteAccommodationCmd,bool>
    {
        private readonly IAccommodationRepository _accomodationRepo;

        public DeleteAccommodationHandler(IAccommodationRepository accommodationRepo)
        {
            _accomodationRepo = accommodationRepo;
        }

        public async Task<bool> Handle(DeleteAccommodationCmd cmd, CancellationToken cancellationToken)
        {
            try
            {
                var exits = await _accomodationRepo.ExistsAsync(cmd.Id);
                if (!exits)
                {
                    throw new Exception("This accommodation does not exist");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problem with context: " + ex.Message, ex);

            }
            try
            {
                var response = await _accomodationRepo.DeleteAsync(cmd.Id);
                return response;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problem with retrieving data from context : " + ex.Message, ex);
            }
        }
    }
}
