using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Feedback.Queries.GetAllFeedback
{
    public class FeedbackDto
    {
        public int FeedbackId { get; set; }
        public int ProductId { get; set; }
        public string Email { get; set; }
        public string SubmittedOn { get; set; }
        public int Rating { get; set; }
        public string Content { get; set; }
        public bool IsShow { get; set; }

    }
}
