using HotelsRegistry.Application.Feature.Accommodations.Commands;
using HotelsRegistry.Application.Feature.Accommodations.Mappers;
using HotelsRegistry.Domain.AbstractRepository;
using HotelsRegistry.Domain.Entities;
using MediatR;

namespace HotelsRegistry.Application.Feature.Accommodations.Handlers
{
    public class UpdateAccommodationHandler : IRequestHandler<UpdateAccommodationCmd,bool>
    {
        private readonly IAccommodationRepository _accomodationRepo;

        public UpdateAccommodationHandler(IAccommodationRepository accommodationRepo)
        {
            _accomodationRepo = accommodationRepo;
        }

        public async Task<bool> Handle(UpdateAccommodationCmd cmd, CancellationToken cancellationToken)
        {
            var accommodation = AccommodationMapper.Mapper.Map<Accommodation>(cmd);


            if (accommodation is null)
            {
                throw new ApplicationException("There is an issue with mapping while creating new accommodation");

            }
            try
            {
                var exits = await _accomodationRepo.ExistsAsync(accommodation.Id);
                if(!exits)
                {
                    throw new Exception("This accommodation does not exist");
                }
            }
            catch(Exception ex)
            {
                throw new ApplicationException("Problem with context: " + ex.Message, ex);

            }
            try
            {
                accommodation.UpdateAt = DateTime.UtcNow;
                await _accomodationRepo.UpdateAsync(accommodation);
                await _accomodationRepo.SaveAllAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problem with accommodation update: " + ex.Message, ex);
            }
        }
    }
}
