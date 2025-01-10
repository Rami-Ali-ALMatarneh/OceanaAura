using MediatR;
using OceanaAura.Application.Features.ProductSize.Queries.GetAllSize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.ProductSize.Queries.GetSizeDetails
{
    public record SizeDetailsQuery(int Id) : IRequest<SizeDetailsDto>;

}
