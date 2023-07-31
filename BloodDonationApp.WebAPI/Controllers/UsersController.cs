using BloodDonationApp.Business.DTOs.Requests;
using BloodDonationApp.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BloodDonationApp.WebAPI.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
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
    }
}
