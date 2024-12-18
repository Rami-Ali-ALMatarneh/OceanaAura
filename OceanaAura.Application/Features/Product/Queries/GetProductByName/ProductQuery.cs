using MediatR;
using OceanaAura.Application.Features.LookUp.Queries.GetAllProductCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Product.Queries.GetProductByName
{
    public record ProductQuery(string Name) : IRequest<ProductDto>;
}
