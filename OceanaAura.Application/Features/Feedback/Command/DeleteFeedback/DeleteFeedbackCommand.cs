using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Feedback.Command.DeleteFeedback
{
    public class DeleteFeedbackCommand : IRequest<Unit>
    {
        public int FeedbackId { get; set; }
    }
}
