using OceanaAura.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Persistence
{
    public interface IBottleImgRepository : IGenericRepository<BottleImg>
    {
        Task<BottleImg> GetFilteredBottleImgAsync(int sizeId,int lidId, int colorId);
    }
}
