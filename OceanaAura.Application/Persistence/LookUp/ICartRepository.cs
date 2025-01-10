using OceanaAura.Domain.Entities;
using OceanaAura.Domain.Entities.LookUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Persistence.LookUp
{
    public interface ICartRepository : IGenericRepository<Cart>
    {
        Task<Cart> GetCartWithOrderId(int id); 
    }
}
