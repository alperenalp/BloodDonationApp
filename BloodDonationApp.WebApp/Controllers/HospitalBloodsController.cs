using BloodDonationApp.Business.DTOs.Requests;
using BloodDonationApp.Business.DTOs.Responses;
using BloodDonationApp.Business.Services;
using BloodDonationApp.Business.Validators;
using BloodDonationApp.WebApp.Models.HospitalBlood;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

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

        [Authorize(Roles = "Hospital")]
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
            CreateHospitalBloodValidator validationRules = new CreateHospitalBloodValidator();
            ValidationResult results = validationRules.Validate(request);
            if (results.IsValid)
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (!await _hospitalBloodService.IsExistsBloodInHospital((int)request.BloodId, (int)user.HospitalId))
                {
                    await _hospitalBloodService.AddNeedForBloodAsync(request, (int)user.HospitalId);
                    return View();
                }
                ModelState.AddModelError("", "Bu kan ihtiyacı zaten eklenmiş.");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [Authorize(Roles = "Hospital")]
        public async Task<IActionResult> ListBloodNeeds(int id)
        {
            if (id == 0)
            {
                id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.PrimarySid).Value);
            }
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
                    BloodId = item.BloodId,
                    BloodType = await _bloodService.GetBloodTypeByIdAsync(item.BloodId),
                    Quantity = item.Quantity,
                });
            }
            return hospitalBloodsVM;
        }

        [Authorize(Roles = "User")]
        public async Task<IActionResult> ListHospitalsForNeedsBlood(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            var hospitals = await _hospitalBloodService.GetHospitalListForNeedsBloodByBloodIdAsync((int)user.BloodId);
            if (hospitals.Count() <= 0)
            {
                ModelState.AddModelError("", "Teşekkür ederiz. Hiçbir hastanenin kan grubunuzdan ihtiyacı bulunmamaktadır.");
            }
            return View(hospitals);
        }

        [Authorize(Roles = "Hospital")]
        public async Task<IActionResult> Edit(int id)
        {
            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.PrimarySid).Value);
            var user = await _userService.GetUserByIdAsync(userId);
            var hospitalBlood = await _hospitalBloodService.GetHospitalBloodForUpdateAsync((int)user.HospitalId, id);
            var editHospitalBloodVM = await getEditHospitalBloodVMAsync(id, hospitalBlood);
            return View(editHospitalBloodVM);
        }

        private async Task<EditHospitalBloodVM> getEditHospitalBloodVMAsync(int bloodId, UpdateHospitalBloodRequest hospitalBlood)
        {
            return new EditHospitalBloodVM
            {
                BloodId = hospitalBlood.BloodId,
                HospitalId = hospitalBlood.HospitalId,
                BloodType = await _bloodService.GetBloodTypeByIdAsync(bloodId),
                Quantity = hospitalBlood.Quantity,
            };
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateHospitalBloodRequest request)
        {
            var isHospitalExists = await _hospitalBloodService.IsExistsBloodInHospital(request.BloodId, request.HospitalId);
            if (isHospitalExists)
            {
                if (ModelState.IsValid)
                {
                    await _hospitalBloodService.UpdateHospitalBloodAsync(request);
                    return RedirectToAction(nameof(ListBloodNeeds));
                }
                return View();
            }
            return NotFound();
        }
    }
}
