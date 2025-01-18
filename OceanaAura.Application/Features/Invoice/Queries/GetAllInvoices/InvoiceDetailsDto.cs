using OceanaAura.Application.Features.Order.Queries.GetAllOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Invoice.Queries.GetAllInvoices
{
    public class InvoiceDetailsDto
    {
        public int InvoiceId { get; set; }
        //Customer Details
        public int OrderId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        //Address Details

        public string Address { get; set; }
        public string City { get; set; }
        public string? PostalCode { get; set; } //optional
        public string? Apartment { get; set; } //optional
        public int RegionId { get; set; }
        public string DeliveryRegion { get; set; }
        // Payment currency
        public string Region { get; set; }

        //Pricing Details
        public decimal SubTotal { get; set; }
        public string SubTotalString { get; set; }

        public decimal Shipping { get; set; }
        public string ShippingString { get; set; }
        public string TotalLidPriceString { get; set; }

        public decimal TotalPrice { get; set; }
        public string TotalPriceString { get; set; }
        public string CreateOn { get; set; }

        //Cart Details

        public List<CartDto> Carts { get; set; }
    }
}
