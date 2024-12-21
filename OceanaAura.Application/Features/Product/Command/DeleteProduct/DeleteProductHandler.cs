using MediatR;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Exceptions;
using OceanaAura.Application.Features.LookUp.Commands.DeleteCategory;
using OceanaAura.Application.Persistence;
using OceanaAura.Domain.Entities;
using OceanaAura.Domain.Entities.LookUp;
using OceanaAura.Domain.Entities.ProductsEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Product.Command.DeleteProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, Unit>
    {

        private readonly IAppLogger<DeleteProductHandler> _appLogger;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductHandler(IAppLogger<DeleteProductHandler> appLogger, IUnitOfWork unitOfWork)
        {
            _appLogger = appLogger;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            //validation request data
            var Product = await _unitOfWork.GenericRepository<Domain.Entities.ProductsEntities.Product>().GetByIdAsync(request.Id);
            var Imgs = await _unitOfWork.productRepository.GetImgsByForeignIdAsync(request.Id);
            //verify that record exists
            if (Product == null && Imgs == null)
            {
                _appLogger.LogWarning("Validation errors in Delete request {0} - {1}", nameof(Product), request.Id);
                throw new NotFoundException("Invalid to Delete Products, is Not Found!");
            }
            // add to database
            _unitOfWork.GenericRepository<Domain.Entities.ProductsEntities.Product>().Remove(Product);
            _unitOfWork.GenericRepository<Domain.Entities.Image>().ReomveRange(Imgs);
            await _unitOfWork.CompleteSaveAppDbAsync();
            //return record Id
            return Unit.Value;
        }
    }
}
