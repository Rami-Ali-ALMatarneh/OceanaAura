using AutoMapper;
using FluentValidation;
using MediatR;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Exceptions;
using OceanaAura.Application.Features.ProductColor.Commands.AddColor;
using OceanaAura.Application.Persistence;
using OceanaAura.Domain.Entities.LookUp;
using OceanaAura.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.LookUp.Commands.AddCagegory
{
    public class AddProductCategoryCommadHandler : IRequestHandler<AddProductCategoryCommad, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<AddProductCategoryCommadHandler> _appLogger;

        public AddProductCategoryCommadHandler(IMapper mapper, IUnitOfWork unitOfWork, IAppLogger<AddProductCategoryCommadHandler> appLogger)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _appLogger = appLogger;
        }

        public async Task<int> Handle(AddProductCategoryCommad request, CancellationToken cancellationToken)
        {
            //validation request data
            var validator = new AddProductCategoryValidator(_unitOfWork);
            var ValidationResult = await validator.ValidateAsync(request);
            if (ValidationResult.Errors.Any())
            {
                var errorMessages = ValidationResult.Errors.Select(e => e.ErrorMessage).ToList();

                _appLogger.LogWarning("Validation errors in Create request {0} - {1}", nameof(AddProductCategoryCommad), request.NameEn);
                throw new BadRequestException(errorMessages);
            }

            // convert to domain entity
            var data = _mapper.Map<LookUpEntity>(request);
            data.LookupCategoryId = (int)LookUpEnums.CategoryCode.ProductCategory;
            // add to database
            await _unitOfWork.GenericRepository<LookUpEntity>().AddAsync(data);
            await _unitOfWork.CompleteSaveAppDbAsync();
            //return record Id
            return data.Id;
        }
    }
}
