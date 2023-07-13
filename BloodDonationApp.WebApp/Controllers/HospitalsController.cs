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
    [Authorize(Roles = "Admin")]
    public class HospitalsController : Controller
    {
        private readonly IHospitalService _hospitalService;
        private readonly IUserService _userService;

        public HospitalsController(IHospitalService hospitalService, IUserService userService)
        {
            _hospitalService = hospitalService;
            _userService = userService;
        }

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
        public async Task<IActionResult> Create(CreateNewHospitalRequest request)
        {
            if (ModelState.IsValid)
            {
                await _hospitalService.CreateHospitalAsync(request);
                return Redirect(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Detail(int id)
        {
            var hospital = _hospitalService.GetHospitalByIdAsync(id);
            var hospitalUsers = _userService.GetUserListAsync();
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Users = await getHospitalUsersSelectListAsync();
            var hospital = await _hospitalService.GetHospitalForUpdateAsync(id);
            return View(hospital);
        }

        private async Task<IEnumerable<UserDisplayResponse>> getHospitalUsersAsync()
        {
            var users = await _userService.GetUserListAsync();
            return users.Where(x => x.Type == "Hospital");
        }

        private async Task<IEnumerable<SelectListItem>> getHospitalUsersSelectListAsync()
        {
            var users = await getHospitalUsersAsync();
            return users.Select(x => new SelectListItem { Text = x.Username, Value = x.Id.ToString() });
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
    }
}
