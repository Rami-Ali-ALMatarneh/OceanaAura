using OceanaAura.Domain.Common;
using OceanaAura.Domain.Entities.LookUp;
using OceanaAura.Domain.Entities.ProductsEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Domain.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string Email {  get; set; }
        public string Region { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string? PostalCode { get; set; } //optional
        public string? Apartment { get; set; } //optional
        public int? Discount { get; set; }
        public int StatusId { get; set; }
        public int RegionId { get; set; }

        public List<Cart> carts { get; set; }

    }
}
