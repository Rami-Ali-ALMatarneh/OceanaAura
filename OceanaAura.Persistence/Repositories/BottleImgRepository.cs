using Microsoft.EntityFrameworkCore;
using OceanaAura.Application.Persistence;
using OceanaAura.Application.Persistence.LookUp;
using OceanaAura.Domain.Entities;
using OceanaAura.Persistence.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Persistence.Repositories
{
    public class BottleImgRepository : GenericRepository<BottleImg>, IBottleImgRepository
    {
        private readonly OeanaAuraDbContext _appDbContext;
        public BottleImgRepository(OeanaAuraDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<BottleImg> GetFilteredBottleImgAsync(int sizeId, int lidId, int colorId)
        {
            var filteredBottleImg = await _appDbContext.bottleImgs
                     .FirstOrDefaultAsync(b => b.SizeId == sizeId && b.LidId == lidId && b.ColorId == colorId);

            return filteredBottleImg;
        }
    }
}
