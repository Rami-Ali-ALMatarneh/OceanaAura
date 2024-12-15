using MediatR;
using OceanaAura.Application.Features.ProductColor.Commands.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.ProductSize.Command.AddSize
{
    public class AddSizeCommand : IRequest<int>
    {
        public string NameEn { get; set; }
        public string NameAr { get; set; }
    }
}
