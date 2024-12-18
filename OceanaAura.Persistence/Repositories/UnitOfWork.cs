using OceanaAura.Application.Persistence;
using OceanaAura.Application.Persistence.LookUp;
using OceanaAura.Identity.DbContext;
using OceanaAura.Persistence.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OeanaAuraDbContext _oeanaAuraDbContext;
        private readonly UserIdentityDbContext _userIdentityDbContext;

        public UnitOfWork(OeanaAuraDbContext oeanaAuraDbContext, UserIdentityDbContext userIdentityDbContext)
        {
           _oeanaAuraDbContext = oeanaAuraDbContext;
            _userIdentityDbContext = userIdentityDbContext;
        }
        public async Task<bool> CompleteSaveIdentityAsync()
        {
            return await _userIdentityDbContext.SaveChangesAsync() > 0;
        }
        public async Task<bool> CompleteSaveAppDbAsync()
        {
            return await _oeanaAuraDbContext.SaveChangesAsync() > 0;
        }
        public IGenericRepository<TEntity> GenericRepository<TEntity>() where TEntity : class
        {
            return new GenericRepository<TEntity>(_oeanaAuraDbContext);
        }
        public IProductColorRepository productColorRepository => new ProductColorRepository(_oeanaAuraDbContext);
        public IProductSizeRepository productSizeRepository => new ProductSizeRepository(_oeanaAuraDbContext);
        public ILookUpRepository lookUpRepository => new LookUpRepository(_oeanaAuraDbContext);

        public IProductRepository productRepository =>  new ProductRepository(_oeanaAuraDbContext);
    }
}
