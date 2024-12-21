using MediatR;
using OceanaAura.Application.Features.ContactUs.Queries.GetAllContactUs;
using OceanaAura.Application.Features.LookUp.Common;
using OceanaAura.Application.Features.LookUp.Queries.GetAllAdditinalProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Product.Queries.GetAllProduct
{
    public class PaginatedProductQuery : IRequest<(List<GetProductDto> productDtos , int TotalRecords)>
    {
        public int Start { get; set; }
        public int Length { get; set; }
        public string SearchValue { get; set; }
        public string SortColumn { get; set; }
        public string SortDirection { get; set; }
    }
}