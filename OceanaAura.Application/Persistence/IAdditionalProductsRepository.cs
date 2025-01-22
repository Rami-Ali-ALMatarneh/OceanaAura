using OceanaAura.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Persistence
{
    public interface IAdditionalProductsRepository
    {
        Task<List<AdditionalProduct>> GetAllPaymentMethod();
        Task<AdditionalProduct> GetCustomizationFeesAsync();
    }
}
