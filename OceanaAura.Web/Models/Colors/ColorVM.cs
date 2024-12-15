using FluentValidation;
using OceanaAura.Web.Models.Auth;
using System.Text.RegularExpressions;

namespace OceanaAura.Web.Models.Colors
{
    public class ColorVM
    {
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string? ImageURL { get; set; }
        public IFormFile FormFile { get; set; }
    }
    public class ColorVMValidator : AbstractValidator<ColorVM>
    {
        public ColorVMValidator()
        {
            RuleFor(p => p.NameEn)
                .MinimumLength(2).WithMessage("NameEn must be at least 2 characters long")
                .MaximumLength(50).WithMessage("{PropertyName} can have a maximum of 50 characters");

            RuleFor(p => p.NameAr)
                .MinimumLength(2).WithMessage("{PropertyName} must be at least 2 characters long")
                .MaximumLength(50).WithMessage("{PropertyName} can have a maximum of 50 characters");

            RuleFor(p => p.FormFile)
                .Must(HaveValidImageExtension).WithMessage("{PropertyName} must have a valid image file extension (.jpg, .jpeg, .png, .gif, .bmp, .tiff, .webp)");
        }

        private bool HaveValidImageExtension(IFormFile file)
        {
            try
            {
                var imageExtensionsPattern = @"\.(jpg|jpeg|png|gif|bmp|tiff|webp)$";
                return Regex.IsMatch(file.FileName, imageExtensionsPattern, RegexOptions.IgnoreCase);
            }
            catch
            {
                // If an exception occurs, return false
                return false;
            }
        }
    }

}

