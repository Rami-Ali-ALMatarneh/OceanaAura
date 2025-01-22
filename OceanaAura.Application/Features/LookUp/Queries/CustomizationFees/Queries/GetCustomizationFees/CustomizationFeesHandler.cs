using AutoMapper;
using MediatR;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Features.LookUp.Queries.GetAllAdditinalProduct;
using OceanaAura.Application.Features.LookUp.Queries.GetAllPayment;
using OceanaAura.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.LookUp.Queries.CustomizationFees.Queries.GetCustomizationFees
{
    public class CustomizationFeesHandler : IRequestHandler<CustomizationFeesQuery, CustomizationFeesDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<CustomizationFeesHandler> _appLogger;

        public CustomizationFeesHandler(IMapper mapper, IUnitOfWork unitOfWork, IAppLogger<CustomizationFeesHandler> appLogger)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _appLogger = appLogger;
        }
        public async Task<CustomizationFeesDto> Handle(CustomizationFeesQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var Customization = await _unitOfWork.additionalProductsRepository.GetCustomizationFeesAsync();

            // convert data objects to DTO objects
            var data = _mapper.Map<CustomizationFeesDto>(Customization);
            // return list of DTO object
            return data;
        }
    }
}
