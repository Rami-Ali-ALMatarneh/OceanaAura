using System.ComponentModel.DataAnnotations;

namespace OceanaAura.Web.Models.BuyVM
{
    public class OrderRequest
    {
        public int SizeId { get; set; }
        public string Region { get; set; }
        public string Details { get; set; }

        public decimal Shipping { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int LidId { get; set; }
        public string LidName { get; set; }
        public decimal LidPrice { get; set; }
        public int Quantity { get; set; }
        public int ColorId { get; set; }
        public int PaymentId { get; set; }
        public int ProductId { get; set; }
        public bool IsCustomize { get; set; } = false;
        public string? FontFamily { get; set; }
        public string? Text { get; set; }
        public decimal? CustomizationFees { get; set; }

        [Required(ErrorMessage = "Region is required.")]
        public int RegionId { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@gmail\.com$", ErrorMessage = "Please provide a valid Gmail address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^(?:\+962|0)?7[789]\d{7}$|^(?:\+971|0)?5[024568]\d{7}$", ErrorMessage = "Please provide a valid phone number (Jordanian or UAE format).")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(100, ErrorMessage = "Address cannot exceed 100 characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }

        [StringLength(20, ErrorMessage = "Postal code cannot exceed 20 characters.")]
        public string? PostalCode { get; set; } // optional

        [StringLength(100, ErrorMessage = "Apartment details cannot exceed 100 characters.")]
        public string? Apartment { get; set; } // optional
    }
}
