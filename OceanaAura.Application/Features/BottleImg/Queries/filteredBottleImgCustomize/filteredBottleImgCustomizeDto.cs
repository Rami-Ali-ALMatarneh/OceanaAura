﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.BottleImg.Queries.filteredBottleImgCustomize
{
    public class filteredBottleImgCustomizeDto
    {
        public int Id { get; set; }
        public string ImgUrlFront { get; set; }
        public string ImgUrlBack { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }
        public int LidId { get; set; }
    }
}
