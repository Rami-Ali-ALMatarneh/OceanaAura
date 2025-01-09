using MediatR;
using OceanaAura.Application.Features.Feedback.Queries.GetAllFeedback;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Feedback.Queries.GetIsShowFeedback
{
    public record GetIsShowFeedbackQuery : IRequest<List<FeedbackDto>>;
}
