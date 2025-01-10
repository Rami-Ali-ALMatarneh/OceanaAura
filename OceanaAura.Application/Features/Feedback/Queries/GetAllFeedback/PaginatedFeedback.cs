
using MediatR;
using OceanaAura.Application.Features.ContactUs.Queries.GetAllContactUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Feedback.Queries.GetAllFeedback
{
    public class PaginatedFeedback : IRequest<(List<FeedbackDto>  feedbacks, int TotalRecords)>
    {
        public int Start { get; set; }
        public int Length { get; set; }
        public string SearchValue { get; set; }
        public string SortColumn { get; set; }
        public string SortDirection { get; set; }
        public string SearchDate { get; set; } 
    }
}
