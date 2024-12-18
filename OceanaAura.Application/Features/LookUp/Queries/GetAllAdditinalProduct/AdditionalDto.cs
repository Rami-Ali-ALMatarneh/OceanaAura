using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.LookUp.Queries.GetAllAdditinalProduct
{
    public class AdditionalDto
    {
        public int Id { get; set; }
        public int LookUpId { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }

        public decimal PriceJor { get; set; }
        public decimal PriceUae { get; set; }
        public decimal PriceUsd { get; set; }
    }
}
