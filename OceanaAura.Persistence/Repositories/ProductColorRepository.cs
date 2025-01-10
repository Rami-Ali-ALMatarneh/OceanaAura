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
    public class ProductColorRepository : GenericRepository<LookUpEntity>,IProductColorRepository
    {
        private readonly OeanaAuraDbContext _appDbContext;
        public ProductColorRepository(OeanaAuraDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<bool> IsNameArUnique(string Name)
        {
            var result = await _appDbContext.lookups.AnyAsync(p => p.NameAr == Name && p.LookupCategoryId == (int)LookUpEnums.CategoryCode.ProductColor);
            return !result;
           }

        public async Task<bool> IsNameEnUnique(string Name)
        {
            var result = await _appDbContext.lookups.AnyAsync(p => p.NameEn == Name && p.LookupCategoryId == (int)LookUpEnums.CategoryCode.ProductColor);
            return !result; 
        }
            IQueryable<LookUpEntity> IProductColorRepository.GetAllColor()
        {
            return _appDbContext.lookups.Where(x => x.LookupCategoryId == (int)LookUpEnums.CategoryCode.ProductColor && !x.IsDeleted)
                .AsQueryable().AsNoTracking();
        }
        public async Task<bool> IsNameArUnique(string Name,int id)
        {
            var result = await _appDbContext.lookups.AnyAsync(p => p.NameAr == Name && p.LookupCategoryId == (int)LookUpEnums.CategoryCode.ProductColor && p.LookUpId != id);
            return !result;
        }

        public async Task<bool> IsNameEnUnique(string Name, int id)
        {
            var result = await _appDbContext.lookups.AnyAsync(p => p.NameEn == Name && p.LookupCategoryId == (int)LookUpEnums.CategoryCode.ProductColor && p.LookUpId != id);
            return !result;
        }

        public async Task<List<LookUpEntity>> GetALLColors()
        {
            return await _appDbContext.lookups.Where(x => x.LookupCategoryId == (int)LookUpEnums.CategoryCode.ProductColor && !x.IsDeleted).AsNoTracking()
            .ToListAsync();
        }
    }
}
