using Api.Database.Entity.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swc.Service;
using swcApi.Utils;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace swcApi.Controllers
{
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/User")]
    public class UserController : Controller
    {
        private readonly AppSettings _appSettings;

        private readonly IUserService _userService;

        public UserController(IUserService userService,
            IOptions<AppSettings> appSettings)
        {
            this._appSettings = appSettings.Value;
            _userService = userService;
        }


        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(string userId, string password)
        {
            User user = _userService.Validate(userId, password);
            if (user == null)
            {
                return NotFound("Incorrect UserId or Password");
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(AppSettings.SECRET);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "myid")
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            string tokenString = tokenHandler.WriteToken(token);
            return Ok(tokenString);
        }
        [HttpGet("all")]
        public IActionResult GetUsers()
        {
            return Ok(_userService.GetUsers());
        }
        [HttpPost("add")]
        public IActionResult addUser([FromBody] User user)
        {
            User createdUser = _userService.InsertUser(user);
            if (createdUser == null)
                return StatusCode(StatusCodes.Status409Conflict, "User Already Exists");
            return Ok(createdUser);
        }
    }
}