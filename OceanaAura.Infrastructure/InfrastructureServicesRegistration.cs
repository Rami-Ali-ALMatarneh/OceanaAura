using EcommerceOnion.Application.Services;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OceanaAura.Application.Contracts.Email;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Contracts.OTP;
using OceanaAura.Application.Contracts.RenderView;
using OceanaAura.Application.Models.Email;
using OceanaAura.Infrastructure.RenderServices;
using OceanaAura.Infrastructure.Logging;
using OceanaAura.Infrastructure.OTPService;
using OceanaAura.Infrastructure.RenderServices;
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
            services.AddScoped<IViewRenderService, ViewRenderService>();
            services.AddScoped<IViewEngine, RazorViewEngine>();
            services.AddTransient<IOTPGenerator, OTPGenerator>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddMvcCore();
            return services;
        }
    }
}
