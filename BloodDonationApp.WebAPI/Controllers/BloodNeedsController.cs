using BloodDonationApp.Business.DTOs.Requests;
using BloodDonationApp.Business.DTOs.Responses;
using BloodDonationApp.Business.Services;
using BloodDonationApp.Business.Validators;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Security.Claims;

namespace BloodDonationApp.WebAPI.Controllers
{
    [Route("api/bloodneeds")]
    [ApiController]
    public class BloodNeedsController : ControllerBase
    {
        private readonly IHospitalBloodService _hospitalBloodService;
        private readonly IUserService _userService;

        public BloodNeedsController(IHospitalBloodService hospitalBloodService, IUserService userService)
        {
            _hospitalBloodService = hospitalBloodService;
            _userService = userService;
        }

        [Authorize(Roles = "Hospital")]
        [HttpGet]
        public async Task<IActionResult> GetAllBloodNeeds()
        {
            var userId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.PrimarySid).Value);
            var user = await _userService.GetUserByIdAsync(userId);
            var hospitalBloods = await _hospitalBloodService.GetHospitalBloodListAsync((int)user.HospitalId);
            return Ok(hospitalBloods);
        }

        [Authorize(Roles = "Hospital")]
        [HttpPost("{bloodId:int}")]
        public async Task<IActionResult> CreateBloodNeed([FromRoute(Name = "bloodId")] int bloodId,
            [FromBody] CreateNewHospitalBloodRequest request)
        {
            CreateHospitalBloodValidator validationRules = new CreateHospitalBloodValidator();
            ValidationResult results = validationRules.Validate(request);
            if (results.IsValid)
            {
                var userId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.PrimarySid).Value);
                var user = await _userService.GetUserByIdAsync(userId);
                if (request.BloodId == bloodId)
                {
                    var isExistsBloodInHospital = await _hospitalBloodService.IsExistsBloodInHospital((int)request.BloodId, (int)user.HospitalId);
                    if (!isExistsBloodInHospital)
                    {
                        await _hospitalBloodService.AddNeedForBloodAsync(request, (int)user.HospitalId);
                        return StatusCode(201, request);
                    }
                    ModelState.AddModelError("", "Bu kan ihtiyacı zaten eklenmiş.");
                }
                else
                {
                    return BadRequest(new
                    {
                        StatusCode = 400,
                        Message = $"BloodId with id:{bloodId} could not match request with id:{request.BloodId}"
                    });
                }
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return BadRequest(ModelState);
        }

        [Authorize(Roles = "Hospital")]
        [HttpPut("{bloodId:int}")]
        public async Task<IActionResult> UpdateBloodNeed([FromRoute(Name = "bloodId")] int bloodId,
            [FromBody] UpdateHospitalBloodRequest request)
        {
            var userId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.PrimarySid).Value);
            var user = await _userService.GetUserByIdAsync(userId);
            var isHospitalExists = await _hospitalBloodService.IsExistsBloodInHospital(request.BloodId, (int)user.HospitalId);
            if (isHospitalExists)
            {
                if (request.BloodId == bloodId)
                {
                    request.HospitalId = (int)user.HospitalId;
                    if (ModelState.IsValid)
                    {
                        await _hospitalBloodService.UpdateHospitalBloodAsync(request);
                        return Ok(request);
                    }
                    return BadRequest(ModelState);
                }
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = $"BloodId with id:{bloodId} could not match request with id:{request.BloodId}"
                });
            }
            return NotFound();
        }

        [Authorize(Roles = "Hospital")]
        [HttpDelete("{bloodId:int}")]
        public async Task<IActionResult> DeleteBloodNeedByBloodId([FromRoute(Name = "bloodId")] int bloodId)
        {
            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.PrimarySid).Value);
            var user = await _userService.GetUserByIdAsync(userId);
            var isHospitalBloodExists = await _hospitalBloodService.IsExistsBloodInHospital(bloodId, (int)user.HospitalId);
            if (isHospitalBloodExists)
            {
                await _hospitalBloodService.DeleteHospitalBloodAsync(bloodId, (int)user.HospitalId);
                return NoContent();
            }
            return NotFound(new
            {
                StatusCode = 404,
                Message = $"Blood with id:{bloodId} could not found."
            });
        }
    }
}
