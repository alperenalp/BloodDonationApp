using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using BloodDonationApp.Entities;
using BloodDonationApp.Business.DTOs.Requests;
using BloodDonationApp.Business.Services;

namespace BloodDonationApp.WebApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string? returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(ValidateUserLoginRequest request, string? returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.ValidateUserAsync(request);
                if (user != null)
                {
                    Claim[] claims = new Claim[]
                    {
                        new Claim(ClaimTypes.PrimarySid, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, user.IsAdmin.ToString()),
                    };
                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(principal);

                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return Redirect("/");
                }
                ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış");
            }
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreateNewUserRequest request)
        {
            if (ModelState.IsValid)
            {
                await _userService.CreateUserAsync(request);
                return Redirect(nameof(Login));
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}
