using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using OceanaAura.Application.Contracts.Identity;
using OceanaAura.Application.Exceptions;
using OceanaAura.Application.Models.Identity.Login;
using OceanaAura.Application.Models.Identity.Password;
using OceanaAura.Web.Models.Auth;

namespace OceanaAura.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AuthController(IAuthService authService,IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }
        // GET: Auth/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Auth/Login
        [HttpPost]
        [ValidateAntiForgeryToken] // CSRF Protection
        public async Task<IActionResult> Login(LoginVM request)
        {
            if (!ModelState.IsValid)
                return View(request);
            try
            {
                var loginRequest = _mapper.Map<LoginRequest>(request);
                var response = await _authService.Login(loginRequest);
                return RedirectToAction("Dashboard", "Admin"); // Redirect to a default page after successful login
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
        // GET: ForgotPassword
        [HttpGet]
        [Route("Auth/ForgetPassword")]
        public IActionResult ForgetPassword()
        {
            return View();
        }

        // POST: Auth/ForgetPassword
        [HttpPost]
        [ValidateAntiForgeryToken] // CSRF Protection
        public async Task<IActionResult> ForgetPassword(ForgetPasswordVM forgetPassword)
        {
            if (!ModelState.IsValid)
            {
                return View(forgetPassword);
            }
            try
            {
                var request = _mapper.Map<ForgetPasswordRequest>(forgetPassword);
                await _authService.ForgetPassword(request);
                TempData["Message"] = "OTP has been sent successfully.";
                return RedirectToAction("ResetPassword", "Auth");
            }
            catch (NotFoundException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(forgetPassword);
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(forgetPassword);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(forgetPassword);
            }
        }
        [HttpGet]
        [Route("Auth/ResetPassword")]
        public IActionResult ResetPassword()
        {
            // You can pass the ViewBag.Message directly to the view
            ViewBag.Message = TempData["Message"] as string;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM resetPassword)
        {
            if (!ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(resetPassword.OTP))
                {
                    ModelState.AddModelError(nameof(resetPassword.OTP), "OTP is required.");
                }
                return View(resetPassword);
            }
            var ResetPasswordRequest = _mapper.Map<ResetPasswordRequest>(resetPassword);
            try
            {
               var IsValid = await _authService.ResetPassword(ResetPasswordRequest);
                if (!IsValid){
                    ModelState.AddModelError(nameof(resetPassword.OTP), "Invalid OTP, Please Enter Valid OTP.");
                    return View(resetPassword);

                }
                return RedirectToAction("NewPassword", "Auth", new { otp = resetPassword.OTP });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(resetPassword.OTP), ex.Message);
                return View(resetPassword);
            }
        }

        [HttpGet]
        [Route("Auth/NewPassword")]
        public IActionResult NewPassword(string otp)
        {
            if (string.IsNullOrEmpty(otp))
            {
                // Handle missing OTP scenario
                ModelState.AddModelError(string.Empty, "OTP is required to reset the password.");
                return RedirectToAction("ResetPassword", "Auth");
            }
            ViewBag.OTP = otp;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewPassword(NewPasswordVM newPasswordVM)
        {
            if (!ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(newPasswordVM.NewPassword))
                {
                    ModelState.AddModelError(nameof(newPasswordVM.NewPassword), "The New Password is required.");
                }
                // Ensure the OTP is passed correctly from the view
                if (string.IsNullOrEmpty(newPasswordVM.OTP))
                {
                    ModelState.AddModelError(string.Empty, "something went wrong, Please try again Send OTP to Make Reset Passowrd");
                }
                return View(newPasswordVM);
            }
           
            var newPasswordRequest = _mapper.Map<ChangePasswordRequest>(newPasswordVM);

            try
            {
                var result = await _authService.ChangePasswordAsync(newPasswordRequest);

                if (result.Succeeded)
                {
                    TempData["NewPasswordUpdate"] = "Password changed successfully.";
                    return RedirectToAction("Login","Auth"); 
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message); // Show the specific error message
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An unexpected error occurred while changing the password.");
            }
            return View(newPasswordVM);
        }

    }
}
