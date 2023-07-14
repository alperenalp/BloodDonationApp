using BloodDonationApp.Business.DTOs.Requests;
using BloodDonationApp.Business.DTOs.Responses;
using BloodDonationApp.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonationApp.WebApp.Controllers
{
    public class HospitalBloodsController : Controller
    {
        private readonly IHospitalBloodService _hospitalBloodService;
        private readonly IUserService _userService;

        public HospitalBloodsController(IHospitalBloodService hospitalBloodService, IUserService userService)
        {
            _hospitalBloodService = hospitalBloodService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddNeedForBlood(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNeedForBlood(CreateNewHospitalBloodRequest request, int id)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.GetUserByIdAsync(id);
                await _hospitalBloodService.AddNeedForBloodAsync(request, (int)user.HospitalId);
            }
            return View();
        }

        public async Task<IActionResult> ListBloodNeeds(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            var hospitalBloods = await _hospitalBloodService.GetHospitalNeedBloodListAsync((int)user.HospitalId);
            return View(hospitalBloods);
        }

    }
}
