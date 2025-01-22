using MediatR;
using OceanaAura.Application.Features.BottleImg.Queries.filteredBottleImg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.BottleImg.Queries.filteredBottleImgCustomize
{
    public class filteredBottleImgCustomizeQuery : IRequest<filteredBottleImgCustomizeDto>
    {
        public int SizeId { get; set; }
        public int LidId { get; set; }
        public int ColorId { get; set; }
    }
}
