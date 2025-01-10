using OceanaAura.Domain.Entities;
using OceanaAura.Domain.Entities.LookUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Persistence.LookUp
{
    public interface IProductSizeRepository
    {
        Task<ProductSize> GetProductSizeAsync(int sizeId);
        Task<List<ProductSize>> GetAllProductSizesAsync();
        IQueryable<LookUpEntity> GetAllSize();
        Task<bool> IsNameEnUnique(string Name);
        Task<bool> IsNameArUnique(string Name);


    }
}
