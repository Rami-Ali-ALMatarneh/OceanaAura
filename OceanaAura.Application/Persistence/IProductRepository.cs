using OceanaAura.Domain.Entities;
using OceanaAura.Domain.Entities.LookUp;
using OceanaAura.Domain.Entities.ProductsEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Persistence
{
    public interface IProductRepository : IGenericRepository<Product> {
        Task<Product> GetProductByName(string name);
        Task<Product> GetProduct(string name, int id);

        Task<List<Image>> GetImgsByForeignIdAsync(int id);
        Task<List<Product>> GetAllProducts();
    }
}
