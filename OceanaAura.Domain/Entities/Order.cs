using OceanaAura.Domain.Common;
using OceanaAura.Domain.Entities.LookUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Domain.Entities
{
    public class Order : BaseEntity
    {
        public string Email {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string? PostalCode { get; set; } //optional
        public string? Apartment { get; set; } //optional

        public LookUpEntity Region { get; set; } //lookup
        public int RegionId { get; set; }
        public LookUpEntity Payment { get; set; } //lookup
        public int PaymentId { get; set; }

        //  منتج البيع القالب 

        public decimal SubTotal { get; set; }
        public decimal Shipping {  get; set; }
        public decimal TotalPrice { get; set; }

    }
}
