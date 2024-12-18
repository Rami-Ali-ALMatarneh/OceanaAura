using Microsoft.EntityFrameworkCore;
using OceanaAura.Application.Persistence;
using OceanaAura.Application.Persistence.LookUp;
using OceanaAura.Domain.Entities.LookUp;
using OceanaAura.Domain.Entities.ProductsEntities;
using OceanaAura.Domain.Enums;
using OceanaAura.Persistence.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly OeanaAuraDbContext _appDbContext;
        public ProductRepository(OeanaAuraDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Product> GetProductByName(string name)
        {
            return await _appDbContext.products.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
