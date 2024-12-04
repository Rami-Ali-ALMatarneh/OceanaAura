using FluentValidation.AspNetCore;
using OceanaAura.Web.Models.Auth;

namespace OceanaAura.Web.Models
{
    public static class FluentValidationsServiceRegistration
    {
        [Obsolete]
        public static IServiceCollection AddFluentValidations(this IServiceCollection services) {
            services.AddControllersWithViews()
                  .Services.AddFluentValidation(fv => {
                      fv.RegisterValidatorsFromAssemblyContaining<LoginVMValidator>();
                      fv.RegisterValidatorsFromAssemblyContaining<ForgetPasswordVMValidator>();
                      fv.RegisterValidatorsFromAssemblyContaining<ResetPasswordVMValidator>();
                      fv.RegisterValidatorsFromAssemblyContaining<UpdateInfoValidator>();
                      fv.RegisterValidatorsFromAssemblyContaining<ChangePasswordVMValidator>();
                  });
            return services;
        }
    }
}
