using MediatR;
using OceanaAura.Application.Features.ContactUs.Queries.GetAllContactUs;
using OceanaAura.Application.Features.LookUp.Common;
using OceanaAura.Application.Features.LookUp.Queries.GetProductCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.LookUp.Queries.GetAllAdditinalProduct
{
    public class PaginatedAdditionalQuery : PaginatedLookUpQuery, IRequest<(List<AdditionalDto> additionalDtos, int TotalRecords)>;
}
