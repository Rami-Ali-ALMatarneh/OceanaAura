using Hangfire;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OceanaAura.Application.Persistence;
using OceanaAura.Application.Persistence.LookUp;
using OceanaAura.Persistence.AppDbContext;
using OceanaAura.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
       IConfiguration configuration)
        {
            services.AddDbContext<OeanaAuraDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("OceanaAuraConnectionString")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductColorRepository, ProductColorRepository>();
            services.AddScoped<IProductSizeRepository, ProductSizeRepository>();
            services.AddScoped<ILookUpRepository, LookUpRepository>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
         
            return services;
        }
    }
}
