using BloodDonationApp.Business.DTOs.Requests;
using BloodDonationApp.Business.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace BloodDonationApp.WebAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationsController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public AuthenticationsController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateNewUserRequest request)
        {
            if (ModelState.IsValid)
            {
                await _userService.CreateUserAsync(request);
                return StatusCode(201, request);
            }
            return BadRequest(ModelState);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] ValidateUserLoginRequest request)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.ValidateUserAsync(request);
                if (user != null)
                {
                    var jwtSettings = _configuration.GetSection("JwtSettings");
                    var key = Encoding.UTF8.GetBytes(jwtSettings["secretKey"]);
                    var securityKey = new SymmetricSecurityKey(key);
                    var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                    Claim[] claims = new Claim[]
                    {
                        new Claim(ClaimTypes.PrimarySid, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim(ClaimTypes.Role, user.Type),
                    };

                    var token = new JwtSecurityToken(
                        issuer: jwtSettings["validIssuer"],
                        audience: jwtSettings["validAudience"],
                        claims: claims,
                        notBefore: DateTime.Now,
                        expires: DateTime.Now.AddMinutes(10),
                        signingCredentials: credential
                        );

                    return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
                }
                ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış");
            }
            return BadRequest(ModelState);
        }

    }
}
