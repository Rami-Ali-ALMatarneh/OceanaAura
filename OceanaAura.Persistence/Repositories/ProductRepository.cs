using Microsoft.EntityFrameworkCore;
using OceanaAura.Application.Persistence;
using OceanaAura.Application.Persistence.LookUp;
using OceanaAura.Domain.Entities;
using OceanaAura.Domain.Entities.LookUp;
using OceanaAura.Domain.Entities.ProductsEntities;
using OceanaAura.Domain.Enums;
using OceanaAura.Persistence.AppDbContext;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        public async Task<List<Domain.Entities.Image>> GetImgsByForeignIdAsync(int id)
        {
            return await _appDbContext.Images.Where(x=>x.ProductId==id).ToListAsync();
        }

        public async Task<Product> GetProductByName(string name)
        {
            return await _appDbContext.products.FirstOrDefaultAsync(x => x.Name == name);
        }
        public async Task<Product> GetProduct(string name, int id)
        {
            return await _appDbContext.products.Where(x => x.Id != id).FirstOrDefaultAsync(x => x.Name == name);
        }
       public async Task<List<Product>> GetAllProducts()
        {
            return await _appDbContext.products.Include(x=>x.ProductImages).ToListAsync();

        }

    }
}
