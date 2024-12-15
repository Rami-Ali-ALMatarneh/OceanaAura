using MediatR;
using OceanaAura.Application.Features.LookUp.Common;
using OceanaAura.Application.Features.ProductSize.Queries.GetAllSize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.LookUp.Queries.GetProductCategories
{
    public class PaginatedProductCategoriesQuery : PaginatedLookUpQuery, IRequest<(List<ProductCategoriesDto> productCategories, int TotalRecords)>
    {
    }
}
