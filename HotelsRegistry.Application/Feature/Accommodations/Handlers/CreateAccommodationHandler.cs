using HotelsRegistry.Application.Feature.Accommodations.Commands;
using HotelsRegistry.Application.Feature.Accommodations.Mappers;
using HotelsRegistry.Domain.AbstractRepository;
using HotelsRegistry.Domain.Entities;
using MediatR;

namespace HotelsRegistry.Application.Feature.Accommodations.Handlers
{
    public class CreateAccommodationHandler : IRequestHandler<CreateAccommodationCmd, bool>
    {
        private readonly IAccommodationRepository _accomodationRepo;

        public CreateAccommodationHandler(IAccommodationRepository accommodationRepo)
        {
            _accomodationRepo = accommodationRepo;
        }

        public async Task<bool> Handle(CreateAccommodationCmd cmd, CancellationToken cancellationToken)
        {
            var accommodation = AccommodationMapper.Mapper.Map<Accommodation>(cmd);

            if (accommodation is null)
            {
                throw new ApplicationException("There is an issue with mapping while creating new accommodation");

            }

            try
            {
                await _accomodationRepo.CreateAsync(accommodation);
                await _accomodationRepo.SaveAllAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problem with accommodation creation: " + ex.Message, ex);
            }
        }
    }
}
