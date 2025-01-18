using MediatR;
using OceanaAura.Application.Features.Feedback.Queries.GetAllFeedback;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.BottleImg.Queries.GetAllBottleImg
{
    public class PaginatedBottleImg: IRequest<(List<GetBottleImg> getBottleImgs, int TotalRecords)>
    {
        public int Start { get; set; }
        public int Length { get; set; }
        public string SearchValue { get; set; }
        public string SortColumn { get; set; }
        public string SortDirection { get; set; }
    }
}
