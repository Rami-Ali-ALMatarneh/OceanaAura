using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OceanaAura.Application.Contracts.Email;
using OceanaAura.Application.Contracts.Identity;
using OceanaAura.Application.Contracts.OTP;
using OceanaAura.Application.Contracts.RenderView;
using OceanaAura.Application.Exceptions;
using OceanaAura.Application.Models.Email;
using OceanaAura.Application.Models.Identity;
using OceanaAura.Application.Models.Identity.Login;
using OceanaAura.Application.Models.Identity.Password;
using OceanaAura.Application.Models.Identity.UserInfo;
using OceanaAura.Identity.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Identity.Services
{
    internal class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly JwtSettings _jwtSettings;
        private readonly IEmailService _emailService;
        private readonly IViewRenderService _viewRenderService;
        private readonly IOTPGenerator _oTPGenerator;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(UserManager<User> userManager,
            IOptions<JwtSettings> jwtSettings,
            SignInManager<User> signInManager,
            IEmailService emailService,
            IViewRenderService viewRenderService,
            IOTPGenerator oTPGenerator,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor
            )
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
            _signInManager = signInManager;
            _emailService = emailService;
            _viewRenderService = viewRenderService;
            _oTPGenerator = oTPGenerator;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<LoginResponse> Login(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                throw new NotFoundException($"User not found.");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (result.Succeeded == false)
            {
                throw new BadRequestException($"Invalid Email or Password!");
            }

            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

            var response = new LoginResponse
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = user.Email,
                UserName = user.UserName
            };
            await _signInManager.SignInAsync(user, false);
            return response;
        }

        private async Task<JwtSecurityToken> GenerateToken(User user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = roles.Select(q => new Claim(ClaimTypes.Role, q)).ToList();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
               issuer: _jwtSettings.Issuer,
               audience: _jwtSettings.Audience,
               claims: claims,
               expires: DateTime.Now.AddMinutes(_jwtSettings.DurationInMinutes),
               signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }
        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task ForgetPassword(ForgetPasswordRequest forgetPassword)
        {
            var user = await _userManager.FindByEmailAsync(forgetPassword.Email);

            if (user == null)
            {
                throw new NotFoundException("No user associated with the provided email.");
            }

            user.OTP = _oTPGenerator.GenerateOTP();
            await _userManager.UpdateAsync(user);

            var emailBody = await _viewRenderService.RenderToStringAsync("_ResetPasswordEmail", user.OTP);

            var emailMessage = new EmailMessage
            {
                To = user.Email,
                Subject = "Reset Password",
                Body = emailBody
            };
            try
            {
                await _emailService.SendEmailAsync(emailMessage);
            }
            catch (Exception ex)
            {
                // Optionally, throw a custom exception
                throw new InvalidOperationException("Failed to send email");
            }
        }

        public async Task<bool> ResetPassword(ResetPasswordRequest resetPassword)
        {
            try
            {
                var adminUsers = await _userManager.GetUsersInRoleAsync("Admin");
                var admin = adminUsers.FirstOrDefault(x => x.OTP == resetPassword.OTP);
                return admin != null;
            }
            catch (Exception ex)
            {
                throw new NotFoundException("Invalid OTP, Please Enter Valid OTP.");
            }
        }

        public async Task<IdentityResult> 
            ChangePasswordAsync(ChangePasswordRequest changePassword)
        {
            try
            {
                var adminUsers = await _userManager.GetUsersInRoleAsync("Admin");

                var admin = adminUsers.FirstOrDefault(x => x.OTP == changePassword.OTP);
                if (admin == null)
                {
                    throw new InvalidOperationException("No admin user found with the provided OTP.");
                }
                if (admin.PasswordHash == changePassword.NewPassword)
                {
                    throw new InvalidOperationException("The new password cannot be the same as the old password.");
                }

                var resetToken = await _userManager.GeneratePasswordResetTokenAsync(admin);
                var result = await _userManager.ResetPasswordAsync(admin, resetToken, changePassword.NewPassword);

                if (!result.Succeeded)
                {
                    throw new InvalidOperationException("Failed to Change Password");
                }
                admin.OTP = null;
                await _userManager.UpdateAsync(admin);
                return result;
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("Error during password change: ",ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while changing the password: ");
            }
        }

        public async Task UpdateInfo(UpdateInfoRequest updateInfo)
        {
            if (string.IsNullOrWhiteSpace(updateInfo.Email))
            {
                throw new BadRequestException("Email cannot be empty.");
            }

            var user = await _userManager.FindByEmailAsync(updateInfo.Email);
            if (user == null)
            {
                throw new NotFoundException("No user found with the provided email.");
            }

            if (!string.IsNullOrWhiteSpace(updateInfo.UserName))
            {
                var existingUser = await _userManager.FindByNameAsync(updateInfo.UserName);
                if (existingUser != null && existingUser.Id != user.Id)
                {
                    throw new BadRequestException("Username is already in use.");
                }
                user.UserName = updateInfo.UserName;
            }

            if (!string.IsNullOrWhiteSpace(updateInfo.PhoneNumber))
            {
                user.PhoneNumber = updateInfo.PhoneNumber;
            }
            var currentUser = _httpContextAccessor.HttpContext.User;
            user.ModifyBy = currentUser.Identity?.Name; // Assuming Name holds the username
            user.ModifyOn = DateTime.Now;
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException("Failed to update user information.");
            }
        }

        public async Task<UpdateInfoRequest> GetUserInfo(string UserName)
        {
            var userInfo = await _userManager.FindByNameAsync(UserName);
            var UserInfoDto = _mapper.Map<UpdateInfoRequest>(userInfo);
            return UserInfoDto;
        }

        public async Task<IdentityResult> ChangeNewPassowrd(ChangeNewPassowrd changeNewPassowrd)
        {
            try
            {
                if (changeNewPassowrd.NewPassword != changeNewPassowrd.ConfirmNewPassword)
                {
                    throw new BadRequestException("The new password and confirmation password do not match.");
                }

                var currentUser = _httpContextAccessor.HttpContext.User;
                var userId = currentUser?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (string.IsNullOrEmpty(userId))
                {
                    throw new NotFoundException("User not found in the current context.");
                }

                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    throw new NotFoundException("No user found with the provided User ID.");
                }

                var passwordCheck = await _userManager.CheckPasswordAsync(user, changeNewPassowrd.CurrentPassword);
                if (!passwordCheck)
                {
                    throw new BadRequestException("The current password is incorrect.");
                }

                var result = await _userManager.ChangePasswordAsync(user, changeNewPassowrd.CurrentPassword, changeNewPassowrd.NewPassword);

                if (!result.Succeeded)
                {
                    throw new BadHttpRequestException($"An unexpected error occurred while changing the password");
                }
                
                return result;
            }
            catch (BadRequestException ex)
            {
                throw new BadRequestException(ex.Message);
            }
            catch (NotFoundException ex)
            {
                throw new NotFoundException(ex.Message);
            }
            catch (Exception ex)
            {
                // Log the unexpected error for further investigation
                throw new Exception("An unexpected error occurred. Please try again later.");
            }
        }


    }
}
