using Microsoft.EntityFrameworkCore;
using OceanaAura.Application.Persistence;
using OceanaAura.Application.Persistence.LookUp;
using OceanaAura.Domain.Entities;
using OceanaAura.Domain.Entities.LookUp;
using OceanaAura.Persistence.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Persistence.Repositories
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        private readonly OeanaAuraDbContext _appDbContext;
        public CartRepository(OeanaAuraDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }  
        public async Task<Cart> GetCartWithOrderId(int id)
        {
        return await _appDbContext.Carts.FirstOrDefaultAsync(c => c.OrderId == id); 
        }
    }
}
