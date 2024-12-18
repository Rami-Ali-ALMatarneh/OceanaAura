using AutoMapper;
using MediatR;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.LookUp.Queries.GetAllProductCategories
{
    public class CategoryHandler : IRequestHandler<CategoriesQuery, List<CategoryDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<CategoryHandler> _logger;

        public CategoryHandler(IMapper mapper,
           IUnitOfWork unitOfWork,
            IAppLogger<CategoryHandler> logger)
        {
            this._mapper = mapper;
           _unitOfWork = unitOfWork;
            this._logger = logger;
        }
    public  async Task<List<CategoryDto>> Handle(CategoriesQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var categories =await _unitOfWork.lookUpRepository.GetAllProductsCategory();

            // convert data objects to DTO objects
            var data = _mapper.Map<List<CategoryDto>>(categories);

            // return list of DTO object
            _logger.LogInformation("Products Categories were retrieved successfully");
            return data;
        }
    }
}
