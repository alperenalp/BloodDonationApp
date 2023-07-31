using BloodDonationApp.Business.DTOs.Requests;
using BloodDonationApp.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BloodDonationApp.WebAPI.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/bloods")]
    [ApiController]
    public class BloodsController : ControllerBase
    {
        private readonly IBloodService _bloodService;

        public BloodsController(IBloodService bloodService)
        {
            _bloodService = bloodService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBloods()
        {
            var bloods = await _bloodService.GetAllBloodsAsync();
            return Ok(bloods);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBloodById([FromRoute(Name = "id")] int id)
        {
            var blood = await _bloodService.GetBloodByIdAsync(id);

            if (blood is null)
                return NotFound();

            return Ok(blood);
        }
    }
}
