using FluentValidation;
using MediatR;
using OceanaAura.Application.Features.Product.Queries.GetProductByName;
using OceanaAura.Application.Persistence;
using OceanaAura.Persistence.Repositories;
using OceanaAura.Web.Models.Colors;
using OceanaAura.Web.Models.Lookup;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace OceanaAura.Web.Models.Products
{
    public class ProductVM
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> ImageUrls { get; set; }
        [Required]
        public IFormFileCollection Images { get; set; }
        public string? PriceJOR { get; set; }
        public string? PriceUAE { get; set; }
        public string? PriceUSD { get; set; }
        public int? Discount { get; set; }
        public int CategoryId { get; set; }
        public bool IsBottleCategory => CategoryId == 900;
    }
    public class ProductVMalidator : AbstractValidator<ProductVM>
    {
        private readonly IMediator _mediator;

        public ProductVMalidator(IMediator mediator)
        {
            _mediator = mediator;

            RuleFor(p => p.Name)
                .NotNull().WithMessage("{PropertyName} is required.")
                .MinimumLength(2).WithMessage("{PropertyName} must be at least 2 characters long.")
                .MaximumLength(30).WithMessage("{PropertyName} can have a maximum of 30 characters.")
                .MustAsync(UniqueName).WithMessage("Name already exists!");

            RuleFor(p => p.Description)
                .NotNull().WithMessage("{PropertyName} is required.")
                .MaximumLength(500).WithMessage("{PropertyName} can have a maximum of 500 characters.");

            // Pricing validation when the category is not "Bottle"
            RuleFor(p => p.PriceJOR)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .Must(BeValidPrice).WithMessage("Price JOR must be a valid number greater than zero.")
                .When(p => !p.IsBottleCategory && p.CategoryId!=0);

            RuleFor(p => p.PriceUAE)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .Must(BeValidPrice).WithMessage("Price UAE must be a valid number greater than zero.")
                .When(p => !p.IsBottleCategory && p.CategoryId != 0);

            RuleFor(p => p.PriceUSD)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .Must(BeValidPrice).WithMessage("Price USD must be a valid number greater than zero.")
                .When(p => !p.IsBottleCategory && p.CategoryId != 0);

            RuleFor(p => p.Discount)
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be at least 0.")
                .LessThanOrEqualTo(100).WithMessage("{PropertyName} must be at most 100.");

            RuleFor(p => p.CategoryId)
                .NotEmpty().WithMessage("Product Category is required.")
                .GreaterThan(0).WithMessage("Product category must be selected.");

            RuleFor(p => p.Images)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleForEach(p => p.Images)
                .Must(HaveValidImagesExtension).WithMessage("Each image must have a valid file extension. Supported formats: .jpg, .jpeg, .png, .gif, jfif.");
        }

        private bool BeValidPrice(string price)
        {
            if (string.IsNullOrWhiteSpace(price)) return true; // Allow null or empty
            return decimal.TryParse(price, out var result) && result > 0;
        }

        private bool HaveValidImagesExtension(IFormFile file)
        {
            var validExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".jfif" };
            var fileExtension = System.IO.Path.GetExtension(file.FileName).ToLower();
            return validExtensions.Contains(fileExtension);
        }

        private async Task<bool> UniqueName(string name, CancellationToken token)
        {
            var existingProduct = await _mediator.Send(new ProductQuery(name));
            return existingProduct == null;
        }
    }

}
