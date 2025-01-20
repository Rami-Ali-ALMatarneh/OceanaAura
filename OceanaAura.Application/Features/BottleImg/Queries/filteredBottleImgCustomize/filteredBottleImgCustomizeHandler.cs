using AutoMapper;
using MediatR;
using OceanaAura.Application.Features.BottleImg.Queries.filteredBottleImg;
using OceanaAura.Application.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.BottleImg.Queries.filteredBottleImgCustomize
{
    public class filteredBottleImgCustomizeHandler : IRequestHandler<filteredBottleImgCustomizeQuery, filteredBottleImgCustomizeDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public filteredBottleImgCustomizeHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<filteredBottleImgCustomizeDto> Handle(filteredBottleImgCustomizeQuery request, CancellationToken cancellationToken)
        {
            // Retrieve the data from the repository based on the query parameters
            var bottleImg = await _unitOfWork.bottleImgRepository.GetFilteredBottleImgAsync(
                request.SizeId,
                request.LidId,
                request.ColorId);

            if (bottleImg == null)
            {
                // Handle the case where no matching bottle image is found
                return null; // or throw an exception, depending on your requirements
            }

            // Map the retrieved entity to the DTO
            var filteredBottleImgCustomizeDto = _mapper.Map<filteredBottleImgCustomizeDto>(bottleImg);

            return filteredBottleImgCustomizeDto;
        }
    }
}