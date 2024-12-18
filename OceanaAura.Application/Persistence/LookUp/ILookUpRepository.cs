using OceanaAura.Application.Models.Product;
using OceanaAura.Domain.Entities.LookUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Persistence.LookUp
{
    public interface ILookUpRepository : IGenericRepository<LookUpEntity>
    {
        IQueryable<LookUpEntity> GetProductsCategory();
       Task<List<LookUpEntity>> GetAllProductsCategory();
        IQueryable<LookUpEntity> GetAdditinalProducts();
        Task<LookUpEntity> GetLookUpByName(string name);
    }
}
