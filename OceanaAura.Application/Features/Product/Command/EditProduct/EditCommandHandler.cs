using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Exceptions;
using OceanaAura.Application.Features.ProductColor.Commands.UpdateColor;
using OceanaAura.Application.Persistence;
using OceanaAura.Domain.Entities.LookUp;
using OceanaAura.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Product.Command.EditProduct
{
    public class EditCommandHandler : IRequestHandler<EditProductCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IAppLogger<EditCommandHandler> _appLogger;
        private readonly IUnitOfWork _unitOfWork;

        public EditCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IAppLogger<EditCommandHandler> logger)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _appLogger = logger;
        }
        public async Task<int> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var ProductRepository = _unitOfWork.GenericRepository<Domain.Entities.ProductsEntities.Product>();

            // Start building the query
            var query = ProductRepository.Query();

            // Include related data
            query = query.Include(ap => ap.ProductImages)
                         .Include(p => p.Category);

            // Use FirstOrDefaultAsync to asynchronously fetch the product by its Id
            var product = await query
                                .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken); // Fetch the product by its Id

            product.Name = request.Name;
            product.Description = request.Description;
            product.PriceJOR = request.PriceJOR;
            product.PriceUSD = request.PriceUSD;
            product.PriceUAE = request.PriceUAE;
            product.Discount = request.Discount;

            if (product.CategoryId != request.CategoryId)
            {
                product.CategoryId = request.CategoryId;
                product.Category = await _unitOfWork.lookUpRepository.GetByIdAsync(product.CategoryId);
            }
            if (request.ImageUrls != null) {
                var images = request.ImageUrls?.Select(url => new Domain.Entities.Image
                {
                    ImageUrl = url, // Assign the image URL
                                    // Optionally, you can assign other properties like AltText here if needed
                }).ToList();
                // Save all the Images to the database
                foreach (var image in images)
                {
                    image.ProductId = product.Id;  // Set the ProductId for each image
                }
                await _unitOfWork.GenericRepository<Domain.Entities.Image>().AddRangeAsync(images);
            }
            _unitOfWork.GenericRepository<Domain.Entities.ProductsEntities.Product>().Update(product);
            await _unitOfWork.CompleteSaveAppDbAsync();

            //return record Id
            return product.Id;
        }
    }
}
