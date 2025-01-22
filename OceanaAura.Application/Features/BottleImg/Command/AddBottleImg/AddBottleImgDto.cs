using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.BottleImg.Command.AddBottleImg
{
    public class AddBottleImgDto : IRequest<int>
    {
        public string ImgUrlFront { get; set; }
        public string ImgUrlBack { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }

        public int LidId { get; set; }
    }
}
