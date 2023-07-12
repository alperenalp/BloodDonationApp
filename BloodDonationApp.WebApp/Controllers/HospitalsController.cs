using BloodDonationApp.Business.DTOs.Requests;
using Microsoft.AspNetCore.Mvc;
using BloodDonationApp.Business.Services;
using Microsoft.AspNetCore.Authorization;
using BloodDonationApp.WebApp.Models;

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
                Name = request.Name,
                Username = request.Username, 
                Password = request.Password, 
                Type = "Hospital" 
            };
        }
    }
}
