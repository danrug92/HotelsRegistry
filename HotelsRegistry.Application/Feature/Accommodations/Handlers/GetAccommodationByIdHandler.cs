using HotelsRegistry.Application.Feature.Accommodations.Dto;
using HotelsRegistry.Application.Feature.Accommodations.Mappers;
using HotelsRegistry.Application.Feature.Accommodations.Queries;
using HotelsRegistry.Domain.AbstractRepository;
using MediatR;

namespace HotelsRegistry.Application.Feature.Accommodations.Handlers
{
    public class GetAccommodationByIdHandler : IRequestHandler<GetAccommodationByIdQuery,AccommodationDto>
    {
        private readonly IAccommodationRepository _accomodationRepo;

        public GetAccommodationByIdHandler(IAccommodationRepository accommodationRepo)
        {
            _accomodationRepo = accommodationRepo;
        }

        public async Task<AccommodationDto> Handle(GetAccommodationByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var accommodation = await _accomodationRepo.GetByIdAsync(query.Id);
                var response = AccommodationMapper.Mapper.Map<AccommodationDto>(accommodation);
                return response;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problem with retrieving data from context : " + ex.Message, ex);
            }
        }
    }
}
