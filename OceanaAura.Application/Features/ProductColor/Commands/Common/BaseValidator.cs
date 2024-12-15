using FluentValidation;
using OceanaAura.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.ProductColor.Commands.Common
{
    public class BaseValidator<T> : AbstractValidator<T> where T : ColorInfo
    {
        private readonly IUnitOfWork _unitOfWork;

        protected BaseValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(p => p.NameEn)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MustAsync(EnUnique).WithMessage("{PropertyName} is Already Exist!")
            .MinimumLength(2).WithMessage("{PropertyName} must be at least 2 characters long")
            .MaximumLength(50).WithMessage("{PropertyName} can have a maximum of 50 characters");

            RuleFor(p => p.NameAr)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .MustAsync(ArUnique).WithMessage("{PropertyName} is Already Exist!")
               .MinimumLength(2).WithMessage("{PropertyName} must be at least 2 characters long")
               .MaximumLength(50).WithMessage("{PropertyName} can have a maximum of 50 characters");

            RuleFor(p => p.ImageUrl)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .Must(BeAValidImageUrl).WithMessage("{PropertyName} must be a valid image URL")
               .MaximumLength(1000).WithMessage("{PropertyName} can have a maximum of {MaxLength} characters");
            _unitOfWork = unitOfWork;
        }
        private bool BeAValidImageUrl(string url)
        {
            var imageExtensionsPattern = @"\.(jpg|jpeg|png|gif|bmp|tiff|webp)$";
            return Regex.IsMatch(url, imageExtensionsPattern, RegexOptions.IgnoreCase);
        }
        private async Task<bool> EnUnique(string name, CancellationToken token)
        {
            var isExist = await _unitOfWork.productColorRepository.IsNameEnUnique(name);
            return isExist;
        }
        private async Task<bool> ArUnique(string name, CancellationToken token)
        {
            var isExist = await _unitOfWork.productColorRepository.IsNameArUnique(name);
            return isExist;
        }

    }
}
