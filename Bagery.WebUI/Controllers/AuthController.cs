using Bagery.Business.DTOs.AuthDTOs;
using Bagery.Business.Services.IAuthServices;
using Bagery.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bagery.WebUI.Controllers
{
    public class AuthController(IAuthServices _authServices, UserManager<AppUser> _userManager) : Controller
    {
        [HttpGet]
        public IActionResult RegisterUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterDto dto)
        {
            var result = await _authServices.RegisterAsync(dto);
            return result.Success ? RedirectToAction("LogIn", "Auth") : View();
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(LoginDto dto)
        {
            var result = await _authServices.LoginAsync(dto);
            if (result.Success)
            {
                var user = await _userManager.FindByEmailAsync(dto.Email);
                if (user != null)
                {
                    var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

                    if (isAdmin)
                    {
                        return RedirectToAction("Index", "About", new { area = "Admin" });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Promotion", new { area = "User" });
                    }
                }
            }

            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            var result = await _authServices.LogoutAsync();
            return result.Success ? RedirectToAction("Index", "Default") : View();
        }
    }
}
