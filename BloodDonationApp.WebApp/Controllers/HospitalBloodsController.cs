using BloodDonationApp.Business.DTOs.Requests;
using BloodDonationApp.Business.DTOs.Responses;
using BloodDonationApp.Business.Services;
using BloodDonationApp.WebApp.Models.Hospital;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BloodDonationApp.WebApp.Controllers
{
    public class HospitalBloodsController : Controller
    {
        private readonly IHospitalBloodService _hospitalBloodService;
        private readonly IBloodService _bloodService;
        private readonly IUserService _userService;

        public HospitalBloodsController(IHospitalBloodService hospitalBloodService, IUserService userService, IBloodService bloodService)
        {
            _hospitalBloodService = hospitalBloodService;
            _userService = userService;
            _bloodService = bloodService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddNeedForBlood(int id)
        {
            ViewBag.Bloods = await getBloodsForSelectListAsync();
            return View();
        }

        private async Task<IEnumerable<SelectListItem>> getBloodsForSelectListAsync()
        {
            var bloods = await _bloodService.GetAllBloodsAsync();
            return bloods.Select(x => new SelectListItem
            {
                Text = x.Type,
                Value = x.Id.ToString(),
            });
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
            var hospitalBloods = await _hospitalBloodService.GetHospitalBloodListAsync((int)user.HospitalId);
            var hospitalBloodsVM = await getHospitalBloodsVMAsync(hospitalBloods);
            return View(hospitalBloodsVM);
        }

        private async Task<IEnumerable<ListHospitalBloodVM>> getHospitalBloodsVMAsync(IEnumerable<HospitalBloodsDisplayResponse> hospitalBloods)
        {
            var hospitalBloodsVM = new List<ListHospitalBloodVM>();
            foreach (var item in hospitalBloods)
            {
                hospitalBloodsVM.Add(new ListHospitalBloodVM
                {
                    BloodType = await _bloodService.GetBloodTypeByIdAsync(item.BloodId),
                    Quantity = item.Quantity,
                });
            }
            return hospitalBloodsVM;
        }

        public async Task<IActionResult> ListHospitalsForNeedsBlood(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            var hospitals = await _hospitalBloodService.GetHospitalListByBloodIdAsync((int)user.BloodId);
            return View(hospitals);
        }
    }
}
