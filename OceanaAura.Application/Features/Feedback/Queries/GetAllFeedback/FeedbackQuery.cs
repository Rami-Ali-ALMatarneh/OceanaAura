using MediatR;
using OceanaAura.Application.Features.ContactUs.Queries.GetContactUsWithDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Feedback.Queries.GetAllFeedback
{
    public record FeedbackQuery : IRequest<List<FeedbackDto>>;
}
