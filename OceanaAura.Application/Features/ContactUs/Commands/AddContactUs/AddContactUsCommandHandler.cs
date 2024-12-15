using AutoMapper;
using MediatR;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Exceptions;
using OceanaAura.Application.Features.ContactUs.Queries.GetAllContactUs;
using OceanaAura.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.ContactUs.Commands.AddContactUs
{
    public class AddContactUsCommandHandler : IRequestHandler<AddContactUsCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<AddContactUsCommandHandler> _appLogger;

        public AddContactUsCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IAppLogger<AddContactUsCommandHandler> appLogger)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _appLogger = appLogger;
        }
        public async Task<int> Handle(AddContactUsCommand request, CancellationToken cancellationToken)
        {
            //validation request data
            var validator = new CraeteContactUsCommandValidator(_unitOfWork);
            var ValidationResult = await validator.ValidateAsync(request);
            if (ValidationResult.Errors.Any())
            {
                var errorMessages = ValidationResult.Errors.Select(e => e.ErrorMessage).ToList();

                _appLogger.LogWarning("Validation errors in Create request {0} - {1}", nameof(Domain.Entities.ContactUs), request.Name);
                throw new BadRequestException($"Invalid Create Contact Us: {errorMessages}");
            }
            // convert to domain entity
            var data = _mapper.Map<Domain.Entities.ContactUs>(request);
            // add to database
            await _unitOfWork.GenericRepository<Domain.Entities.ContactUs>().AddAsync(data);
            await _unitOfWork.CompleteSaveAppDbAsync();
            //return record Id
            return data.Id;
        }
    }
}
