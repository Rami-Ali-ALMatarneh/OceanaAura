using AutoMapper;
using FluentValidation;
using MediatR;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Exceptions;
using OceanaAura.Application.Features.ProductColor.Commands.AddColor;
using OceanaAura.Application.Persistence;
using OceanaAura.Domain.Entities;
using OceanaAura.Domain.Entities.LookUp;
using OceanaAura.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.LookUp.Commands.Additional
{
    public class AddAdditionalCommadHandler : IRequestHandler<AddAdditionalCommad, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<AddAdditionalCommadHandler> _appLogger;

        public AddAdditionalCommadHandler(IMapper mapper, IUnitOfWork unitOfWork, IAppLogger<AddAdditionalCommadHandler> appLogger)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _appLogger = appLogger;
        }

        public async Task<int> Handle(AddAdditionalCommad request, CancellationToken cancellationToken)
        {
            //validation request data
            var validator = new AddAdditionalValidator(_unitOfWork);
            var ValidationResult = await validator.ValidateAsync(request);
            if (ValidationResult.Errors.Any())
            {
                var errorMessages = ValidationResult.Errors.Select(e => e.ErrorMessage).ToList();

                _appLogger.LogWarning("Validation errors in Create request {0} - {1}", nameof(AddAdditionalCommad), request.NameEn);
                throw new BadRequestException(errorMessages);
            }
            var LookUp = new LookUpEntity
            {
                LookupCategoryId = (int)LookUpEnums.CategoryCode.ProductAdditional,
                NameEn = request.NameEn,
                NameAr = request.NameAr,
                CreatedBy = "admin",
                CreatedOn = DateTime.Now
            };
            await _unitOfWork.GenericRepository<LookUpEntity>().AddAsync(LookUp);
            await _unitOfWork.CompleteSaveAppDbAsync();

            var LookupEntity = await _unitOfWork.lookUpRepository.GetLookUpByName(request.NameEn);
            // convert to domain entity

            var data = _mapper.Map<AdditionalProduct>(request);
            data.AdditionalProducts = LookupEntity;
            data.LookUpId = LookupEntity.LookUpId;
            // add to database
            await _unitOfWork.GenericRepository<AdditionalProduct>().AddAsync(data);
            await _unitOfWork.CompleteSaveAppDbAsync();
            //return record Id
            return data.Id;
        }
    }
}
