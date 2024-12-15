using MediatR;
using OceanaAura.Application.Features.ProductColor.Queries.GetAllProductColors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.ProductSize.Queries.GetAllSize
{
    public  class PaginatedProductSizeQuery : IRequest<(List<ProductSizeDto> productSizeDtos, int TotalRecords)>
    {
        public int Start { get; set; }
        public int Length { get; set; }
        public string SearchValue { get; set; }
        public string SortColumn { get; set; }
        public string SortDirection { get; set; }
        public string SearchDate { get; set; } // New field for date search
    }
}
