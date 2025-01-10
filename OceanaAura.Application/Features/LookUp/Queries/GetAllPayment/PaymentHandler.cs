using AutoMapper;
using MediatR;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Features.LookUp.Queries.GetAllRegions;
using OceanaAura.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.LookUp.Queries.GetAllPayment
{
    public class PaymentHandler : IRequestHandler<PaymentQuery, List<PaymentDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<PaymentHandler> _logger;

        public PaymentHandler(IMapper mapper,
           IUnitOfWork unitOfWork,
            IAppLogger<PaymentHandler> logger)
        {
            this._mapper = mapper;
            _unitOfWork = unitOfWork;
            this._logger = logger;
        }

        public async Task<List<PaymentDto>> Handle(PaymentQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var Regions = await _unitOfWork.additionalProductsRepository.GetAllPaymentMethod();

            // convert data objects to DTO objects
            var data = _mapper.Map<List<PaymentDto>>(Regions);
            // return list of DTO object
            _logger.LogInformation("Regions are retrieved successfully");
            return data;
        }
    }
}

