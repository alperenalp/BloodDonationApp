using BloodDonationApp.Business.DTOs.Requests;
using Microsoft.AspNetCore.Mvc;
using BloodDonationApp.Business.Services;
using Microsoft.AspNetCore.Authorization;
using BloodDonationApp.WebApp.Models;
using Microsoft.AspNetCore.Identity;
using BloodDonationApp.Business.DTOs.Responses;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BloodDonationApp.WebApp.Controllers
{
    public class HospitalsController : Controller
    {
        private readonly IHospitalService _hospitalService;
        private readonly IUserService _userService;

        public HospitalsController(IHospitalService hospitalService, IUserService userService)
        {
            _hospitalService = hospitalService;
            _userService = userService;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var hospitals = await _hospitalService.GetHospitalListAsync();
            return View(hospitals);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserHospitalVM request)
        {
            if (ModelState.IsValid)
            {
                var userRequest = getCreateNewUserRequest(request);
                var userId = await _userService.CreateUserAsync(userRequest);
                var hospitalRequest = getNewHospitalRequest(request, userId);
                await _hospitalService.CreateHospitalAsync(hospitalRequest);
                return Redirect(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {

            ViewBag.Users = await getHospitalUsersSelectListAsync();
            var hospital = await _hospitalService.GetHospitalForUpdateAsync(id);
            return View(hospital);
        }

        private async Task<IEnumerable<SelectListItem>> getHospitalUsersSelectListAsync()
        {
            var users = await _userService.GetUserListAsync();
            return users.Where(x => x.Type == "Hospital")
                .Select(x => new SelectListItem { Text = x.Username, Value = x.Id.ToString() });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, UpdateHospitalRequest request)
        {
            var isHospitalExists = await _hospitalService.IsHospitalExistsAsync(id);
            if (isHospitalExists)
            {
                if (ModelState.IsValid)
                {
                    await _hospitalService.UpdateHospitalAsync(request);
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.Users = await getHospitalUsersSelectListAsync();
                return View();
            }
            return NotFound();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var isHospitalExists = await _hospitalService.IsHospitalExistsAsync(id);
            if (isHospitalExists)
            {
                await _hospitalService.DeleteHospitalAsync(id);
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserHospitalVM request)
        {
            if (ModelState.IsValid)
            {
                var userRequest = getCreateNewUserRequest(request);
                var userId = await _userService.CreateUserAsync(userRequest);
                var hospitalRequest = getNewHospitalRequest(request, userId);
                await _hospitalService.CreateHospitalAsync(hospitalRequest);
                return RedirectToAction("Login", "Users");
            }
            return View();
        }

        private CreateNewHospitalRequest getNewHospitalRequest(UserHospitalVM request, int userId)
        {
            return new CreateNewHospitalRequest
            {
                UserId = userId,
                Address = request.Address,
                Name = request.Name,
                Phone = request.Phone,
            };
        }

        private CreateNewUserRequest getCreateNewUserRequest(UserHospitalVM request)
        {
            return new CreateNewUserRequest
            {
                Username = request.Username,
                Password = request.Password,
                Type = "Hospital"
            };
        }
    }
}
