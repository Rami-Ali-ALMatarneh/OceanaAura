using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OceanaAura.Application.Contracts.Email;
using OceanaAura.Application.Models.Email;
using OceanaAura.Infrastructure.EmailService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService, EmailServices>();
            return services;
        }
    }
}
