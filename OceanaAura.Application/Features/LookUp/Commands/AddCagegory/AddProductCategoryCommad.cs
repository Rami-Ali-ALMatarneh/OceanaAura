using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.LookUp.Commands.AddCagegory
{
    public class AddProductCategoryCommad : IRequest<int>
    {
        public string NameEn { get; set; }
        public string NameAr { get; set; }
    }
}