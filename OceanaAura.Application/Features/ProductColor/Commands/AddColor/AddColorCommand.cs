using MediatR;
using OceanaAura.Application.Features.ProductColor.Commands.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.ProductColor.Commands.AddColor
{
    public class AddColorCommand : ColorInfo , IRequest<int>
    {
    }
}
