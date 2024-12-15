using OceanaAura.Application.Persistence;
using OceanaAura.Domain.Entities.LookUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Persistence.LookUp
{
    public interface IProductColorRepository : IGenericRepository<LookUpEntity>
    {
        IQueryable<LookUpEntity> GetAllColor();
        Task<bool> IsNameEnUnique(string Name);
        Task<bool> IsNameArUnique(string Name);
        Task<bool> IsNameEnUnique(string Name,int id );
        Task<bool> IsNameArUnique(string Name, int id);
    }
}
