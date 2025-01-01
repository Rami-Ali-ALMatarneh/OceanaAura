namespace OceanaAura.Web.Models.BuyVM
{
    public class OrderViewModel
    {
        public string Email { get; set; }
        public string Country { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Apartment { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string ShippingMethod { get; set; }
        public string PaymentMethod { get; set; }
        public OrderSummary orderSummary { get; set; }
    }
}
