using FluentValidation;
using OceanaAura.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.ProductColor.Commands.UpdateColor
{
    public class UpdatColorValidator : AbstractValidator<UpdateColorCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdatColorValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;


            RuleFor(p => p.NameEn)
                 .NotEmpty().WithMessage("{PropertyName} is required")
                 .MinimumLength(2).WithMessage("{PropertyName} must be at least 2 characters long")
                 .MaximumLength(50).WithMessage("{PropertyName} can have a maximum of 50 characters")
                 .MustAsync((command, name, token) => EnUnique(name, command.Id, token))
                 .WithMessage("{PropertyName} is already in use!");

            RuleFor(p => p.NameAr)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MinimumLength(2).WithMessage("{PropertyName} must be at least 2 characters long")
                .MaximumLength(50).WithMessage("{PropertyName} can have a maximum of 50 characters")
                .MustAsync((command, name, token) => ArUnique(name, command.Id, token))
                .WithMessage("{PropertyName} is already in use!");


            RuleFor(p => p.ImageUrl)
               .NotEmpty().WithMessage("{PropertyName} is required")
                .Must(BeAValidImageUrl).WithMessage("{PropertyName} must have a valid image file extension (.jpg, .jpeg, .png, .gif, .bmp, .tiff, .webp, .svg, .jfif)")
               .MaximumLength(1000).WithMessage("{PropertyName} can have a maximum of {MaxLength} characters");
            _unitOfWork = unitOfWork;
        }
        private bool BeAValidImageUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return false;
            var imageExtensionsPattern = @"\.(jpg|jpeg|png|gif|bmp|tiff|webp|svg|jfif)$";
            return Regex.IsMatch(url.ToLower(), imageExtensionsPattern, RegexOptions.IgnoreCase);
        }
        private async Task<bool> EnUnique(string name,int id, CancellationToken token)
        {
            var isExist = await _unitOfWork.productColorRepository.IsNameEnUnique(name,id);
            return isExist;
        }
        private async Task<bool> ArUnique(string name, int id, CancellationToken token)
        {
            var isExist = await _unitOfWork.productColorRepository.IsNameArUnique(name,id);
            return isExist;
        }
    }
}
