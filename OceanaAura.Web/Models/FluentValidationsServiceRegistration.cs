using FluentValidation;
using FluentValidation.AspNetCore;
using OceanaAura.Web.Models.Auth;
using OceanaAura.Web.Models.Colors;
using OceanaAura.Web.Models.Size;
using System.Reflection;

namespace OceanaAura.Web.Models
{
    public static class FluentValidationsServiceRegistration
    {
        public static IServiceCollection AddFluentValidations(this IServiceCollection services) {
            services.AddValidatorsFromAssemblyContaining<LoginVMValidator>();
            services.AddValidatorsFromAssemblyContaining<ForgetPasswordVMValidator>();
            services.AddValidatorsFromAssemblyContaining<ResetPasswordVMValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateInfoValidator>();
            services.AddValidatorsFromAssemblyContaining<ChangePasswordVMValidator>();
            services.AddValidatorsFromAssemblyContaining<ColorVMValidator>();
            services.AddValidatorsFromAssemblyContaining<ColorVMValidator>();
            services.AddValidatorsFromAssemblyContaining<SizeVMValidator>();

            return services;
        }
    }
}
