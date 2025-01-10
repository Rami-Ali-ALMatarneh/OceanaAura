using AutoMapper;
using MediatR;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Features.Product.Queries.GetProduct;
using OceanaAura.Application.Features.Product.Queries.GetProductDetails;
using OceanaAura.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Product.Queries.NormalBuy.GetColors
{
    public class GetColorsHandler : IRequestHandler<GetColorQuery, List<ColorDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetColorsHandler> _appLogger;

        public GetColorsHandler(IMapper mapper, IUnitOfWork unitOfWork, IAppLogger<GetColorsHandler> appLogger)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _appLogger = appLogger;
        }

        public async Task<List<ColorDto>> Handle(GetColorQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var colors = await _unitOfWork.productColorRepository.GetALLColors();
            // convert data objects to DTO objects
            var data = _mapper.Map<List<ColorDto>>(colors);
            return data;
        }
    }
}
