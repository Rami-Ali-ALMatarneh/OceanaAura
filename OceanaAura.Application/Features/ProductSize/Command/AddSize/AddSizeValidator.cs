using FluentValidation;
using OceanaAura.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.ProductSize.Command.AddSize
{
    public class AddSizeValidator : AbstractValidator<AddSizeCommand>
    {
        private readonly IUnitOfWork unitOfWork;

        public AddSizeValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(p => p.NameEn)
                 .MustAsync(LeaveTypeEnUnique).WithMessage("NameEn is Already Exist!")
                 .MinimumLength(2).WithMessage("{PropertyName} must be at least 2 characters long")
                 .MaximumLength(50).WithMessage("{PropertyName} can have a maximum of 50 characters");

            RuleFor(p => p.NameAr)
               .MustAsync(LeaveTypeArUnique).WithMessage("NameAr is Already Exist!")
               .MinimumLength(2).WithMessage("{PropertyName} must be at least 2 characters long")
               .MaximumLength(50).WithMessage("{PropertyName} can have a maximum of 50 characters");
            this.unitOfWork = unitOfWork;
        }

        private async Task<bool> LeaveTypeEnUnique(string name, CancellationToken token)
        {
            var isExist =  await unitOfWork.productSizeRepository.IsNameEnUnique(name);
            return isExist;
        }
        private async Task<bool> LeaveTypeArUnique(string name, CancellationToken token)
        {
            var isExist = await unitOfWork.productSizeRepository.IsNameArUnique(name);
            return isExist;
        }
    }
}
