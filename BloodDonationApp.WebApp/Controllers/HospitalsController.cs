using BloodDonationApp.Business.DTOs.Requests;
using Microsoft.AspNetCore.Mvc;
using BloodDonationApp.Business.Services;
using Microsoft.AspNetCore.Authorization;
using BloodDonationApp.WebApp.Models;
using Microsoft.AspNetCore.Identity;
using BloodDonationApp.Business.DTOs.Responses;
using Microsoft.AspNetCore.Mvc.Rendering;
using MediatR;
using BloodDonationApp.Business.Features.Queries.GetAllHospital;
using BloodDonationApp.Business.Features.Commands.CreateHospital;

namespace BloodDonationApp.WebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HospitalsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IHospitalService _hospitalService; 
        private readonly IUserService _userService;

        public HospitalsController(IHospitalService hospitalService, IUserService userService, IMediator mediator)
        {
            _hospitalService = hospitalService;
            _userService = userService;
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(GetAllHospitalQueryRequest getAllHospitalQueryRequest)
        {
            //var hospitals = await _hospitalService.GetHospitalListAsync();
            var response = await _mediator.Send(getAllHospitalQueryRequest);    
            return View(response.Hospitals);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateHospitalCommandRequest createHospitalCommandRequest)
        {
            if (ModelState.IsValid)
            {
                var response = await _mediator.Send(createHospitalCommandRequest);
                //await _hospitalService.CreateHospitalAsync(request);
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
            var hospitalUsers = await _userService.GetHospitalUserListAsync();
            return hospitalUsers.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
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
