using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.LookUp.Commands.DeleteCategory
{
    public class DeleteCategoryCommad : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
