using Api.Database.Entity.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swc.Service;
using swcApi.Utils;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace swcApi.Controllers
{
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/User")]
    public class UserController : Controller
    {
        private readonly AppSettings _appSettings;
        private readonly ILogger _logger;
        private readonly IUserService _userService;

        public UserController(IUserService userService,
            IOptions<AppSettings> appSettings,
            ILogger<UserController> logger)
        {
            this._appSettings = appSettings.Value;
            _userService = userService;
            this._logger = logger;
        }


        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(string userId, string password)
        {
            _logger.LogInformation("Validating User " + userId);
            User user = _userService.Validate(userId, password);
            if (user == null)
            {
                _logger.LogError("Given " + userId + " Not found");
                return NotFound("Incorrect UserId or Password");
            }
            _logger.LogInformation("Given User " + userId +" Found");
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
            _logger.LogInformation(string.Format("Generated Token {0} for User {1}", tokenString, userId));
            return Ok(tokenString);
        }
        [HttpGet("all")]
        public IActionResult GetUsers()
        {
            if (!_userService.GetUsers().Any())
                _logger.LogWarning("No users found");
            return Ok(_userService.GetUsers());
        }
        [HttpPost("add")]
        public IActionResult addUser([FromBody] User user)
        {
            User createdUser = _userService.InsertUser(user);
            if (createdUser == null)
            {
                _logger.LogError("User already exists");
                return StatusCode(StatusCodes.Status409Conflict, "User Already Exists");
            }
            return Ok(createdUser);
        }
    }
}