using OceanaAura.Application.Persistence.LookUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Persistence
{
    public interface IUnitOfWork 
    {
        IGenericRepository<TEntity> GenericRepository<TEntity>() where TEntity : class;
        IProductColorRepository productColorRepository { get; }
        IProductSizeRepository productSizeRepository { get; }
        ILookUpRepository lookUpRepository { get; }
        Task<bool> CompleteSaveIdentityAsync();
        Task<bool> CompleteSaveAppDbAsync();

    }
}
