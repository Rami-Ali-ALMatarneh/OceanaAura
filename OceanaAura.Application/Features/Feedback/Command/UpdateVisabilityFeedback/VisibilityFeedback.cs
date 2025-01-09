using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Feedback.Command.UpdateVisabilityFeedback
{
    public class VisibilityFeedback : IRequest<int>
    {
    public int FeedbackId { get; set; }
    public bool IsShow { get; set; }
}
}
