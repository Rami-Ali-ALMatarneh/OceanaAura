using FluentValidation;
using MediatR;
using OceanaAura.Application.Features.Product.Queries.GetProductByName;
using OceanaAura.Application.Features.Product.Queries.GetProductUnique;
using OceanaAura.Web.Models.Lookup;
using System.ComponentModel.DataAnnotations;

namespace OceanaAura.Web.Models.Products
{
    public class EditProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string>? ImageUrls { get; set; }
        public IFormFileCollection? Images { get; set; }
        public string? PriceJOR { get; set; }
        public string? PriceUAE { get; set; }
        public string? PriceUSD { get; set; }
        public int CategoryId { get; set; }
        public List<CategoryVM> categoryVMs { get; set; }
        public bool IsBottleCategory => CategoryId == 900;
    }
    public class EditProductVMalidator : AbstractValidator<EditProductVM>
    {
        private readonly IMediator _mediator;

        public EditProductVMalidator(IMediator mediator)
        {
            _mediator = mediator;

            RuleFor(p => p.Name)
                .NotNull().WithMessage("{PropertyName} is required.")
                .MinimumLength(2).WithMessage("{PropertyName} must be at least 2 characters long.")
                .MaximumLength(30).WithMessage("{PropertyName} can have a maximum of 30 characters.");
          
            RuleFor(p => new { p.Name, p.Id })
            .MustAsync((model, token) => UniqueName(model.Name, model.Id, token))
            .WithMessage("Name already exists!");
            
            RuleFor(p => p.Description)
                .NotNull().WithMessage("{PropertyName} is required.")
                .MaximumLength(500).WithMessage("{PropertyName} can have a maximum of 500 characters.");

            // Pricing validation when the category is not "Bottle"
            RuleFor(p => p.PriceJOR)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .Must(BeValidPrice).WithMessage("Price JOR must be a valid number greater than zero.")
                .When(p => !p.IsBottleCategory && p.CategoryId != 0);

            RuleFor(p => p.PriceUAE)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .Must(BeValidPrice).WithMessage("Price UAE must be a valid number greater than zero.")
                .When(p => !p.IsBottleCategory && p.CategoryId != 0);

            RuleFor(p => p.PriceUSD)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .Must(BeValidPrice).WithMessage("Price USD must be a valid number greater than zero.")
                .When(p => !p.IsBottleCategory && p.CategoryId != 0);


            RuleFor(p => p.CategoryId)
                .NotEmpty().WithMessage("Product Category is required.")
                .GreaterThan(0).WithMessage("Product category must be selected.");


            RuleForEach(p => p.Images)
                       .Must(HaveValidImagesExtension).WithMessage("Each image must have a valid file extension. Supported formats: .jpg, .jpeg, .png, .gif, jfif.")
                       .When(p => p.Images != null && p.Images.Any());
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

        private async Task<bool> UniqueName(string name,int id, CancellationToken token)
        {
            var existingProduct = await _mediator.Send(new UniqueProductQuery(name,id));
            return existingProduct == null;
        }
    }
}

