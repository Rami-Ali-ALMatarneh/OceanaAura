using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using OceanaAura.Application.Contracts.Identity;
using OceanaAura.Application.Models.Identity;
using OceanaAura.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Identity.Services
{
    internal class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly JwtSettings _jwtSettings;

        public AuthService(UserManager<User> userManager,
            IOptions<JwtSettings> jwtSettings,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
            _signInManager = signInManager;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
