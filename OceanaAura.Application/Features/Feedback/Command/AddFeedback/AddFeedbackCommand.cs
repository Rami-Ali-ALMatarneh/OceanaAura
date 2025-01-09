using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Feedback.Command.AddFeedback
{
    public class AddFeedbackCommand : IRequest<int>
    {
        public int ProductId { get; set; }
        public string Content { get; set; }
        public string Email { get; set; }
        public int Rating { get; set; } 
    }
}
