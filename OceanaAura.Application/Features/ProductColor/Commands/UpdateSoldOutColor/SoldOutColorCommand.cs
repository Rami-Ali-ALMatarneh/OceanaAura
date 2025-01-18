using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.ProductColor.Commands.UpdateSoldOutColor
{
    public class SoldOutColorCommand : IRequest<int>
    {
        public int Id { get; set; }
        public bool IsSoldOut { get; set; }
    }
}
