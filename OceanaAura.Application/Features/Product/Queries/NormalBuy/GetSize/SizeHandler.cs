using AutoMapper;
using MediatR;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Features.Product.Queries.NormalBuy.GetColors;
using OceanaAura.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Product.Queries.NormalBuy.GetSize
{
    public class SizeHandler : IRequestHandler<SizeQuery, List<SizeDto>>
    {
     private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAppLogger<SizeHandler> _appLogger;

    public SizeHandler(IMapper mapper, IUnitOfWork unitOfWork, IAppLogger<SizeHandler> appLogger)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _appLogger = appLogger;
    }

    public async Task<List<SizeDto>> Handle(SizeQuery request, CancellationToken cancellationToken)
    {
        // Query the database
        var sizes = await _unitOfWork.productSizeRepository.GetAllProductSizesAsync();
        // convert data objects to DTO objects
        var data = _mapper.Map<List<SizeDto>>(sizes);
        return data;
    }
}
}
