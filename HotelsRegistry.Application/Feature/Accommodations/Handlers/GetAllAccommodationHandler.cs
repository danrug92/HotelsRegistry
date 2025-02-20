using HotelsRegistry.Application.Feature.Accommodations.Dto;
using HotelsRegistry.Application.Feature.Accommodations.Mappers;
using HotelsRegistry.Application.Feature.Accommodations.Queries;
using HotelsRegistry.Domain.AbstractRepository;
using MediatR;

namespace HotelsRegistry.Application.Feature.Accommodations.Handlers
{
    public class GetAllAccommodationHandler : IRequestHandler<GetAllAccommodationQuery,IEnumerable<AccommodationDto>>
    {
        private readonly IAccommodationRepository _accomodationRepo;

        public GetAllAccommodationHandler(IAccommodationRepository accommodationRepo)
        {
            _accomodationRepo = accommodationRepo;
        }

        public async Task<IEnumerable<AccommodationDto>> Handle(GetAllAccommodationQuery query, CancellationToken cancellationToken)
        {

            try
            {
                var accommodationsList = _accomodationRepo.GetAll().ToList();
                var responseList = AccommodationMapper.Mapper.Map<IEnumerable<AccommodationDto>>(accommodationsList);
                return responseList;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problem with retrieving data from context : " + ex.Message, ex);
            }
        }
    }
}
