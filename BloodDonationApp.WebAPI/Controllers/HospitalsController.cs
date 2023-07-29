using BloodDonationApp.Business.DTOs.Requests;
using BloodDonationApp.Business.Features.Commands.CreateHospital;
using BloodDonationApp.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BloodDonationApp.WebAPI.Controllers
{
    [Authorize]
    [Route("api/hospitals")]
    [ApiController]
    public class HospitalsController : ControllerBase
    {
        private readonly IHospitalService _hospitalService;

        public HospitalsController(IHospitalService hospitalService)
        {
            _hospitalService = hospitalService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHospitals()
        {
            var hospitals = await _hospitalService.GetHospitalListAsync();
            return Ok(hospitals);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetHospitalById([FromRoute(Name = "id")] int id)
        {
            var hospital = await _hospitalService.GetHospitalByIdAsync(id);

            if (hospital is null)
                return NotFound();

            return Ok(hospital);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateHospital([FromBody] CreateNewHospitalRequest request)
        {
            if (ModelState.IsValid)
            {
                await _hospitalService.CreateHospitalAsync(request);
                return StatusCode(201, request);
            }
            return BadRequest(ModelState);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateHospitalById([FromRoute(Name = "id")] int id, [FromBody] UpdateHospitalRequest request)
        {
            var isHospitalExists = await _hospitalService.IsHospitalExistsAsync(id);
            if (isHospitalExists)
            {
                if (request.Id == id)
                {
                    if (ModelState.IsValid)
                    {
                        await _hospitalService.UpdateHospitalAsync(request);
                        return Ok(request);
                    }
                    return BadRequest(ModelState);
                }
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = $"Hospital with id:{id} could not match request with id:{request.Id}"
                });
            }
            return NotFound();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteHospitalById([FromRoute(Name = "id")] int id)
        {
            var isHospitalExists = await _hospitalService.IsHospitalExistsAsync(id);
            if (isHospitalExists)
            {
                await _hospitalService.DeleteHospitalAsync(id);
                return NoContent();
            }

            return NotFound(new
            {
                StatusCode = 404,
                Message = $"Hospital with id:{id} could not found."
            });
        }
    }
}
