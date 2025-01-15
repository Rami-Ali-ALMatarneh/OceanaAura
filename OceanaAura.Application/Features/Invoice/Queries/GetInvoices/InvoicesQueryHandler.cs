using AutoMapper;
using MediatR;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Features.Feedback.Queries.GetAllFeedback;
using OceanaAura.Application.Features.Feedback.Queries.GetIsShowFeedback;
using OceanaAura.Application.Features.Invoice.Queries.GetAllInvoices;
using OceanaAura.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Invoice.Queries.GetInvoices
{
    public class InvoicesQueryHandler : IRequestHandler<InvoicesQuery, List<InvoiceDtos>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<InvoicesQueryHandler> _logger;

        public InvoicesQueryHandler(IMapper mapper,
           IUnitOfWork unitOfWork,
            IAppLogger<InvoicesQueryHandler> logger)
        {
            this._mapper = mapper;
            _unitOfWork = unitOfWork;
            this._logger = logger;
        }

        public async Task<List<InvoiceDtos>> Handle(InvoicesQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var Invoices = await _unitOfWork.GenericRepository<OceanaAura.Domain.Entities.Invoice>().GetAllAsync();

            // convert data objects to DTO objects
            var InvoicesDto = _mapper.Map<List<InvoiceDtos>>(Invoices);

            // return list of DTO object
            _logger.LogInformation("Invoices are retrieved successfully");
            return InvoicesDto;
        }
    }
}
