using AutoMapper;
using MediatR;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Features.Product.Queries.GetProductDetails;
using OceanaAura.Application.Features.ProductSize.Queries.GetAllSize;
using OceanaAura.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.ProductSize.Queries.GetSizeDetails
{
    public class SizeHandler : IRequestHandler<SizeDetailsQuery, SizeDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<SizeHandler> _appLogger;

        public SizeHandler(IMapper mapper, IUnitOfWork unitOfWork, IAppLogger<SizeHandler> appLogger)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _appLogger = appLogger;
        }

        public async Task<SizeDetailsDto> Handle(SizeDetailsQuery request, CancellationToken cancellationToken)
        {
            var ProductSizeRepository = await _unitOfWork.productSizeRepository.GetProductSizeAsync(request.Id);
            var ProductSizeDto = _mapper.Map<SizeDetailsDto>(ProductSizeRepository);

            _appLogger.LogInformation("Size is been retrieved successfully.");
            //reyurn data
            return ProductSizeDto;
        }
    }
}
