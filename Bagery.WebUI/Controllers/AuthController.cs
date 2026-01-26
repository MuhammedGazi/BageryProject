using Bagery.Business.DTOs.AuthDTOs;
using Bagery.Business.Services.IAuthServices;
using Microsoft.AspNetCore.Mvc;

namespace Bagery.WebUI.Controllers
{
    public class AuthController(IAuthServices _authServices) : Controller
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
            return result.Success ? RedirectToAction("Index", "About", new { area = "Admin" }) : View();
        }

        public async Task<IActionResult> LogOut()
        {
            var result = await _authServices.LogoutAsync();
            return result.Success ? RedirectToAction("Index", "Home") : View();
        }
    }
}
