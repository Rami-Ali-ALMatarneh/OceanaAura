using MediatR;
using OceanaAura.Application.Features.BottleImg.Queries.filteredBottleImg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.BottleImg.Queries.GetAllBottleImgs
{
    public class GetAllBottleImgQuery : IRequest<List<GetAllBottleImg>>
    {
    }
}
