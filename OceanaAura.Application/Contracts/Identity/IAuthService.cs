using Microsoft.AspNetCore.Identity;
using OceanaAura.Application.Models.Identity.Login;
using OceanaAura.Application.Models.Identity.Password;
using OceanaAura.Application.Models.Identity.UserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginRequest request);
        Task ForgetPassword(ForgetPasswordRequest forgetPassword);
        Task<bool> ResetPassword(ResetPasswordRequest resetPassword);
        Task<IdentityResult> ChangePasswordAsync(ChangePasswordRequest changePassword);
        Task UpdateInfo(UpdateInfoRequest updateInfo);
        Task<UpdateInfoRequest> GetUserInfo(string UserName);

        Task Logout();
    }
}
