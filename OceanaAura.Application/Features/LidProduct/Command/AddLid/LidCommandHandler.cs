using MediatR;
using AutoMapper;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Persistence;
using OceanaAura.Domain.Entities.ProductsEntities;
using OceanaAura.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using OceanaAura.Domain.Enums;

namespace OceanaAura.Application.Features.LidProduct.Command.AddLid
{
    public class LidCommandHandler : IRequestHandler<LidCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<LidCommandHandler> _appLogger;

        public LidCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IAppLogger<LidCommandHandler> appLogger)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _appLogger = appLogger;
        }

        public async Task<int> Handle(LidCommand request, CancellationToken cancellationToken)
        {
            // Create Image entities from the provided URLs
            var images = request.ImageUrls?.Select(url => new Image
            {
                ImageUrl = url, // Assign the image URL
                // Optionally, you can assign other properties like AltText here if needed
            }).ToList();

            // Create the new Product and associate the images
            var product = new Domain.Entities.ProductsEntities.Product
            {
                Name = request.Name,
                Description = request.Description,
                PriceJOR = request.PriceJOR,
                PriceUAE = request.PriceUAE,
                PriceUSD = request.PriceUSD,
                CategoryId = (int)LookUpEnums.ProductCategory.Lids,
                ProductImages = images ?? new List<Image>() // Associate the images (if any)
            };

            // Save the Product to the database
            await _unitOfWork.GenericRepository<Domain.Entities.ProductsEntities.Product>().AddAsync(product);

            // Save all the Images to the database
            foreach (var image in images)
            {
                image.ProductId = product.Id;  // Set the ProductId for each image
                await _unitOfWork.GenericRepository<Image>().AddAsync(image);
            }

            // Commit the changes to the database
            await _unitOfWork.CompleteSaveAppDbAsync();

            // Return the Product ID
            return product.Id;
        }
    }
}
