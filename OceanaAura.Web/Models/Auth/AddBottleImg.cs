using FluentValidation;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Text.RegularExpressions;

namespace OceanaAura.Web.Models.Auth
{
    public class AddBottleImg
    {
        public IFormFile Img { get; set; }
        public string? ImgUrl { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }
        public int LidId { get; set; }
    }

    public class AddBottleImgValidator : AbstractValidator<AddBottleImg>
    {
        public AddBottleImgValidator()
        {
            // Rule for Img (IFormFile)
            RuleFor(p => p.Img)
                .NotNull().WithMessage("Image is required.")
                .Must(HaveValidImageExtension).WithMessage("Invalid file format. Supported formats: .jpg, .jpeg, .png, .gif, .jfif, .svg.")
                .When(p => string.IsNullOrEmpty(p.ImgUrl)); // Validate only if ImgUrl is not provided

            // Rule for SizeId (int)
            RuleFor(p => p.SizeId)
                .NotEmpty().WithMessage("Size is required.")
                .GreaterThan(0).WithMessage("Size must be greater than 0.");

            // Rule for ColorId (int)
            RuleFor(p => p.ColorId)
                .NotEmpty().WithMessage("Color is required.")
                .GreaterThan(0).WithMessage("Color must be greater than 0.");

            // Rule for LidId (int)
            RuleFor(p => p.LidId)
                .NotEmpty().WithMessage("Lid is required.")
                .GreaterThan(0).WithMessage("Lid must be greater than 0.");
        }

        // Helper method to validate image file extensions
        private bool HaveValidImageExtension(IFormFile file)
        {
            if (file == null) return true; // Skip validation if file is null
            var validExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".jfif", ".svg" };
            var fileExtension = System.IO.Path.GetExtension(file.FileName).ToLower();
            return validExtensions.Contains(fileExtension);
        }
    }
}