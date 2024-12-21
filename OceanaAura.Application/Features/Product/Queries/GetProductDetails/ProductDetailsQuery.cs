using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Product.Queries.GetProductDetails
{
    public record ProductDetailsQuery(int Id) : IRequest<ProductDetailsDto>;
}
