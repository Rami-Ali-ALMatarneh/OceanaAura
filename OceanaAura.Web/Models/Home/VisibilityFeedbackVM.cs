namespace OceanaAura.Web.Models.Home
{
    public class VisibilityFeedbackVM
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
