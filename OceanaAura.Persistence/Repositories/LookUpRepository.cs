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
        public IQueryable<LookUpEntity> GetProductsCategory()
        {
            return  _appDbContext.lookups.Where(x=>x.LookupCategoryId == (int)LookUpEnums.CategoryCode.ProductCategory && !x.IsDeleted).AsNoTracking().AsQueryable();
        }
    }
}
