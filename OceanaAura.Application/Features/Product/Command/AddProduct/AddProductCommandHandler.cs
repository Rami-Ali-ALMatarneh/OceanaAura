using AutoMapper;
using MediatR;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Exceptions;
using OceanaAura.Application.Features.ProductColor.Commands.AddColor;
using OceanaAura.Application.Persistence;
using OceanaAura.Domain.Entities;
using OceanaAura.Domain.Enums;
using static System.Net.Mime.MediaTypeNames;

namespace OceanaAura.Application.Features.Product.Command.AddProduct
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<AddProductCommandHandler> _appLogger;

        public AddProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IAppLogger<AddProductCommandHandler> appLogger)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _appLogger = appLogger;
        }

        public async Task<int> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {

            // Create Image entities from the provided URLs
            var images = request.ImageUrls?.Select(url => new Domain.Entities.Image 
            {
                ImageUrl = url, // Assign the image URL
                // Optionally, you can assign other properties like AltText here if needed
            }).ToList();
            if (request.Discount == null)
                request.Discount = 0;
            var product = _mapper.Map<Domain.Entities.ProductsEntities.Product>(request);

            product.CategoryId = request.CategoryId;
            product.Category = await _unitOfWork.lookUpRepository.GetByIdAsync(product.CategoryId);
            product.ProductImages = images ?? new List<Domain.Entities.Image>();
            //    ProductImages = images ?? new List<Image>() // Associate the images (if any)
            await _unitOfWork.GenericRepository<Domain.Entities.ProductsEntities.Product>().AddAsync(product);

            // Save all the Images to the database
            foreach (var image in images)
            {
                image.ProductId = product.Id;  // Set the ProductId for each image
            }
            await _unitOfWork.GenericRepository<Domain.Entities.Image>().AddRangeAsync(images);

            // Commit the changes to the database
            await _unitOfWork.CompleteSaveAppDbAsync();

            // Return the Product ID
            return product.Id;
        }
    }
}
