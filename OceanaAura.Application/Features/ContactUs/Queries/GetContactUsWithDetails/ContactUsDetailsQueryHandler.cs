using AutoMapper;
using MediatR;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Features.ContactUs.Queries.GetAllContactUs;
using OceanaAura.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.ContactUs.Queries.GetContactUsWithDetails
{
    public class ContactUsDetailsQueryHandler : IRequestHandler<ContactUsDetailsQuery, ContactUsDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<PaginatedContactUsQueryHandler> _appLogger;

        public ContactUsDetailsQueryHandler(IMapper mapper,IUnitOfWork unitOfWork, IAppLogger<PaginatedContactUsQueryHandler> appLogger)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _appLogger = appLogger;
        }

        public async Task<ContactUsDetailsDto> Handle(ContactUsDetailsQuery request, CancellationToken cancellationToken)
        {
            // Query the Dataabse
            var ContactsUs = await _unitOfWork.GenericRepository<Domain.Entities.ContactUs>().GetByIdAsync(request.Id);
            //convert data using mapper Dto
            var data = _mapper.Map<ContactUsDetailsDto>(ContactsUs);
            _appLogger.LogInformation("Contacts Us were retrieved successfully");
            //return data
            return data;
        }
    }
}
