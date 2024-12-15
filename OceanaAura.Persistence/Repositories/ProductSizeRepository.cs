using Microsoft.EntityFrameworkCore;
using OceanaAura.Application.Persistence.LookUp;
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
    public class ProductSizeRepository : GenericRepository<LookUpEntity>, IProductSizeRepository
    {
        private readonly OeanaAuraDbContext _appDbContext;
        public ProductSizeRepository(OeanaAuraDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IQueryable<LookUpEntity> GetAllSize()
        {
            return _appDbContext.lookups.Where(x => x.LookupCategoryId == (int)LookUpEnums.CategoryCode.ProductSize && !x.IsDeleted)
               .AsQueryable().AsNoTracking();
        }

        public async Task<bool> IsNameEnUnique(string Name)
        {
            var result = await _appDbContext.lookups
                                             .AnyAsync(p => p.NameEn == Name && p.LookupCategoryId == (int)LookUpEnums.CategoryCode.ProductSize);
            return !result; // Return true if the name doesn't exist (unique), false if it does
        }
        public async Task<bool> IsNameArUnique(string Name)
        {
            var result = await _appDbContext.lookups
                                             .AnyAsync(p => p.NameAr == Name && p.LookupCategoryId == (int)LookUpEnums.CategoryCode.ProductSize);
            return !result; // Return true if the name doesn't exist (unique), false if it does        }
        }
    }
}
