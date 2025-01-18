using OceanaAura.Domain.Entities.ProductsEntities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OceanaAura.Domain.Entities
{
    public class Feedback
    {
        // Primary key
        public int FeedbackId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [Required]
        [StringLength(1000)]
        public string Content { get; set; }
        [Required]
        public string Email { get; set; }
        public DateTime SubmittedOn { get; set; } = DateTime.Now;
        public int Rating { get; set; } = 0;
        public bool? IsShow { get; set; }
    }
}