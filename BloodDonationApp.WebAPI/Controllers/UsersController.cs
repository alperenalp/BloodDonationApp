using BloodDonationApp.Business.DTOs.Requests;
using BloodDonationApp.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace BloodDonationApp.WebAPI.Controllers
{
    [Authorize]
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IHospitalBloodService _hospitalBloodService;

        public UsersController(IUserService userService, IHospitalBloodService hospitalBloodService)
        {
            _userService = userService;
            _hospitalBloodService = hospitalBloodService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetUserListAsync();
            return Ok(users);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUserById([FromRoute(Name = "id")] int id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user is null)
                return NotFound();

            return Ok(user);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateNewUserRequest request)
        {
            if (ModelState.IsValid)
            {
                await _userService.CreateUserAsync(request);
                return StatusCode(201, request);
            }
            return BadRequest(ModelState);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateUserById([FromRoute(Name = "id")] int id, [FromBody] UpdateUserRequest request)
        {
            var isHospitalExists = await _userService.IsUserExistsAsync(id);
            if (isHospitalExists)
            {
                if (request.Id == id)
                {
                    if (ModelState.IsValid)
                    {
                        await _userService.UpdateUserAsync(request);
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
        public async Task<IActionResult> DeleteUserById([FromRoute(Name = "id")] int id)
        {
            var isHospitalExists = await _userService.IsUserExistsAsync(id);
            if (isHospitalExists)
            {
                await _userService.DeleteUserAsync(id);
                return NoContent();
            }

            return NotFound(new
            {
                StatusCode = 404,
                Message = $"Hospital with id:{id} could not found."
            });
        }


        [Authorize(Roles = "User")]
        [HttpGet("hospitalneeds")]
        public async Task<IActionResult> GetAllHospitalsForBloodNeeds()
        {
            var userId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.PrimarySid).Value);
            var user = await _userService.GetUserByIdAsync(userId);
            var hospitals = await _hospitalBloodService.GetHospitalListForNeedsBloodByBloodIdAsync((int)user.BloodId);
            if (hospitals.Count() == 0)
            {
                ModelState.AddModelError("", "Teşekkür ederiz. Hiçbir hastanenin kan grubunuzdan ihtiyacı bulunmamaktadır.");
            }
            return Ok(hospitals);
        }

    }
}
