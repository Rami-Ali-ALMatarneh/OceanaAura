using MediatR;
using OceanaAura.Application.Features.LookUp.Queries.GetProductCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.LookUp.Queries.GetAllProductCategories
{
    public record CategoriesQuery : IRequest<List<CategoryDto>>;

}
