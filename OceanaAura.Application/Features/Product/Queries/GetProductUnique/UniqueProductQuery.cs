using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Product.Queries.GetProductUnique
{
    public record UniqueProductQuery(string Name, int Id) : IRequest<UniqueProductDto>;
}
