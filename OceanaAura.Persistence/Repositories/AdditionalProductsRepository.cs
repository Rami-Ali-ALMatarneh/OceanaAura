using Microsoft.EntityFrameworkCore;
using OceanaAura.Application.Persistence;
using OceanaAura.Application.Persistence.LookUp;
using OceanaAura.Domain.Entities;
using OceanaAura.Domain.Entities.LookUp;
using OceanaAura.Domain.Enums;
using OceanaAura.Persistence.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Persistence.Repositories
{
    public class AdditionalProductsRepository : GenericRepository<AdditionalProduct>, IAdditionalProductsRepository
    {
        private readonly OeanaAuraDbContext _appDbContext;
        public AdditionalProductsRepository(OeanaAuraDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<AdditionalProduct> GetCustomizationFeesAsync()
        {
            return await _appDbContext.additionalProducts
                .Include(x => x.AdditionalProducts)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.LookUpId == (int)LookUpEnums.ProductAdditionalCategory.Customization && !x.IsDeleted);
        }
        public async Task<List<AdditionalProduct>> GetAllPaymentMethod()
        {
            return await _appDbContext.additionalProducts.Where(x => x.LookUpId == (int)LookUpEnums.ProductAdditionalCategory.DeliveryFee && !x.IsDeleted).Include(x=>x.AdditionalProducts).AsNoTracking().ToListAsync();

        }
    }
}
