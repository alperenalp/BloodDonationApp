using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using BloodDonationApp.Business.DTOs.Requests;
using BloodDonationApp.Business.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using BloodDonationApp.WebApp.Models.User;
using Azure.Core;

namespace BloodDonationApp.WebApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IBloodService _bloodService;
        private readonly IHospitalService _hospitalService;

        public UsersController(IUserService userService, IBloodService bloodService, IHospitalService hospitalService)
        {
            _userService = userService;
            _bloodService = bloodService;
            _hospitalService = hospitalService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> AddHospitalUserToUsers()
        {
            ViewBag.Hospitals = await getHospitalsForSelectListAsync();
            return View();
        }

        private async Task<IEnumerable<SelectListItem>> getHospitalsForSelectListAsync()
        {
            var hospitals = await _hospitalService.GetHospitalListAsync();
            return hospitals.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddHospitalUserToUsers(CreateNewHospitalUserRequest request)
        {
            if (ModelState.IsValid)
            {
                if (request.HospitalId != 0)
                {
                    await _userService.CreateHospitalUserAsync(request);
                    return RedirectToAction("GetHospitalUsers", "Users");
                }
                ViewBag.Hospitals = await getHospitalsForSelectListAsync();
                ModelState.AddModelError("", "Lütfen bir hastane seçiniz.");
                return View();
            }
            ViewBag.Hospitals = await getHospitalsForSelectListAsync();
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetHospitalUsers()
        {
            var hospitalUsers = await getHospitalUsersVM();
            return View(hospitalUsers);
        }

        private async Task<IEnumerable<ListHospitalUserVM>> getHospitalUsersVM()
        {
            var hospitalUsers = await _userService.GetHospitalUserListAsync();
            var response = new List<ListHospitalUserVM>();
            foreach (var user in hospitalUsers)
            {
                response.Add(new ListHospitalUserVM
                {
                    Id = user.Id,
                    Name = user.Name,
                    LastName = user.LastName,
                    Username = user.Username,
                    Password = user.Password,
                    HospitalName = await _hospitalService.GetHospitalNameByIdAsync(user.HospitalId),
                });
            }
            return response;
        }

        public async Task<IActionResult> Register()
        {
            ViewBag.Bloods = await getBloodTypesForSelecListAsync();
            return View();
        }

        private async Task<IEnumerable<SelectListItem>> getBloodTypesForSelecListAsync()
        {
            var bloods = await _bloodService.GetAllBloodsAsync();
            return bloods.Select(x => new SelectListItem { Text = x.Type, Value = x.Id.ToString() });
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreateNewUserRequest request)
        {
            if (ModelState.IsValid)
            {
                bool userIsExists = await _userService.IsExistsUserByUsernameAsync(request.Username);
                if (!userIsExists)
                {
                    await _userService.CreateUserAsync(request);
                    return Redirect(nameof(Login));
                }
                ModelState.AddModelError("", "Bu kullanıcı zaten eklenmiş");
            }
            ViewBag.Bloods = await getBloodTypesForSelecListAsync();
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
                        new Claim(ClaimTypes.Name, user.Username),
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

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> EditHospitalUser(int id)
        {
            ViewBag.Hospitals = await getHospitalsForSelectListAsync();
            var hospitalUser = await _userService.GetHospitalUserByIdForUpdateAsync(id);
            return View(hospitalUser);
        }

        [HttpPost]
        public async Task<IActionResult> EditHospitalUser(int id, UpdateHospitalUserRequest request)
        {
            var isUserExists = await _userService.IsUserExistsAsync(id);
            if (isUserExists)
            {
                if (ModelState.IsValid)
                {
                    await _userService.UpdateHospitalUserAsync(request);
                    return RedirectToAction(nameof(GetHospitalUsers));
                }
                return View(ModelState);
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var isUserExists = await _userService.IsUserExistsAsync(id);
            if (isUserExists)
            {
                await _userService.DeleteUserAsync(id);
                return RedirectToAction(nameof(GetHospitalUsers));
            }
            return NotFound();
        }
    }
}
