﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.BottleImg.Command.DeleteBottleImg
{
    public class DeleteBottleImg : IRequest<Unit>
    {
        public int BottleImgId { get; set; }
    }
}
