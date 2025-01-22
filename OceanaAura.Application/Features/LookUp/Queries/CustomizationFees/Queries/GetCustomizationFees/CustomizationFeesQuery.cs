using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.LookUp.Queries.CustomizationFees.Queries.GetCustomizationFees
{
    public record CustomizationFeesQuery : IRequest<CustomizationFeesDto>;

}
