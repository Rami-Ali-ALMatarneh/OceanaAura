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

namespace OceanaAura.Application.Features.LookUp.Queries.GetAllStatus
{
    public class StatusHandler : IRequestHandler<StatusQuery, List<StatusDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<StatusHandler> _logger;

        public StatusHandler(IMapper mapper,
           IUnitOfWork unitOfWork,
            IAppLogger<StatusHandler> logger)
        {
            this._mapper = mapper;
            _unitOfWork = unitOfWork;
            this._logger = logger;
        }
        public async Task<List<StatusDto>> Handle(StatusQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var Status = await _unitOfWork.lookUpRepository.GetAllStatus();

            // convert data objects to DTO objects
            var data = _mapper.Map<List<StatusDto>>(Status);

            // return list of DTO object
            _logger.LogInformation("Status are retrieved successfully");
            return data;
        }
    }
}
