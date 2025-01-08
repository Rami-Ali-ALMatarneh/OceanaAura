using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Order.Queries.GetAllOrder
{
    public class GetOrdersDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Region { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string? PostalCode { get; set; } //optional
        public string? Apartment { get; set; } //optional
        public int StatusId { get; set; }
        public int RegionId { get; set; }

        public List<CartDto> Carts { get; set; }


       

    }
}
