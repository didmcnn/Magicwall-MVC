using BusinessLayer.Abstract;
using Magicwall.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Magicwall.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserService _authService;

        public AuthController(UserService authService)
        {
            _authService = authService;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var isAuthenticated = await _authService.LoginAsync(model.Email, model.Password);
            if (isAuthenticated)
            {
                // Create claims for the authenticated user
                var claims = new List<Claim>
                {
                    new(ClaimTypes.Name, model.Email),
                    new(ClaimTypes.Email, model.Email)
                };

                // Create identity and principal
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                // Sign in user
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Admin");
            }

            ModelState.AddModelError("", "Invalid email or password.");
            return View(model);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Home");
        }
        [Authorize]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var isRegistered = await _authService.RegisterAsync(model.Username, model.Email, model.Password);
            if (isRegistered)
            {
                TempData["Success"] = "Registration successful!";
                return RedirectToAction("Login");
            }

            ModelState.AddModelError("", "Email is already taken.");
            return View(model);
        }
    }
}
