using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OceanaAura.Application.Contracts.Identity;
using OceanaAura.Application.Exceptions;
using OceanaAura.Application.Models.Identity.Password;
using OceanaAura.Application.Models.Identity.UserInfo;
using OceanaAura.Web.Models.Auth;

namespace OceanaAura.Web.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AdminController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }
        public IActionResult Dashboard()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await _authService.Logout();
            return RedirectToAction("Login", "Auth");
        }
        public async Task<IActionResult> Profile()
        {
            var userDto = await _authService.GetUserInfo(User.Identity.Name);
            var UserVM = _mapper.Map<UpdateInfo>(userDto);
            return View(UserVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken] // CSRF Protection
        public async Task<IActionResult> Profile(UpdateInfo request)
        {
            if (!ModelState.IsValid)
                return View(request);

            try
            {
                var updateInfoRequest = _mapper.Map<UpdateInfoRequest>(request);
                await _authService.UpdateInfo(updateInfoRequest); 
                TempData["UpdateProfile"] = "Profile updated successfully!";
                return RedirectToAction("Profile"); 
            }
            catch (NotFoundException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(request);
            }
            catch (BadRequestException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(request);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An unexpected error occurred. Please try again later.");
                return View(request);
            }
        }
        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var ChangeNewPasswordRequest = _mapper.Map<ChangeNewPassowrd>(model);
                var result = await _authService.ChangeNewPassowrd(ChangeNewPasswordRequest);
                if (result.Succeeded)
                {
                    TempData["ChangePassword"] = "Password has been successfully changed!";
                    return RedirectToAction("Profile", "Admin");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            catch (BadRequestException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            catch (NotFoundException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An unexpected error occurred. Please try again.");
            }
            return View(model);
        }
    }
}
