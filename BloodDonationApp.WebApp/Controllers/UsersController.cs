using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using BloodDonationApp.Business.DTOs.Requests;
using BloodDonationApp.Business.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace BloodDonationApp.WebApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IBloodService _bloodService;

        public UsersController(IUserService userService, IBloodService bloodService)
        {
            _userService = userService;
            _bloodService = bloodService;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Register()
        {
            ViewBag.Bloods = await getBloodTypesForSelecListAsync();
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

        public async Task<IActionResult> Login(string? returnUrl)
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
                        new Claim(ClaimTypes.Role, user.Type),
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

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        public async Task<IActionResult> AccessDenied()
        {
            return View();
        }

        private async Task<IEnumerable<SelectListItem>> getBloodTypesForSelecListAsync()
        {
            var bloods = await _bloodService.GetAllBloodsAsync();
            return bloods.Select(x => new SelectListItem { Text = x.Type, Value = x.Id.ToString() });
        }


    }
}
