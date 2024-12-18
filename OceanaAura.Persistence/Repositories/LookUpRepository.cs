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
    public class LookUpRepository : GenericRepository<LookUpEntity>, ILookUpRepository
    {
        private readonly OeanaAuraDbContext _appDbContext;
        public LookUpRepository(OeanaAuraDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
       public async Task<List<LookUpEntity>> GetAllProductsCategory()
        {
            return await _appDbContext.lookups.Where(x => x.LookupCategoryId == (int)LookUpEnums.CategoryCode.ProductCategory && !x.IsDeleted).AsNoTracking().ToListAsync();

        }

        public IQueryable<LookUpEntity> GetProductsCategory()
        {
            return  _appDbContext.lookups.Where(x=>x.LookupCategoryId == (int)LookUpEnums.CategoryCode.ProductCategory && !x.IsDeleted).AsNoTracking().AsQueryable();
        }
        public IQueryable<LookUpEntity> GetAdditinalProducts()
        {
            return _appDbContext.lookups.Where(x => x.LookupCategoryId == (int)LookUpEnums.CategoryCode.ProductAdditional && !x.IsDeleted).AsNoTracking().AsQueryable();
        }

        public async Task<LookUpEntity> GetLookUpByName(string name)
        {
            return await _appDbContext.lookups.FirstOrDefaultAsync(x => x.NameEn == name);
        }
    }
}
