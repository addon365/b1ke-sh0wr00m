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
    [Route("api/{license:license}/v{version:apiVersion}/[controller]")]
    public class UserController : Controller
    {
        private readonly AppSettings _appSettings;
        private readonly ILogger _logger;
        private readonly IUserService _userService;
        private RequestInfo _reqinfo;

        public UserController(IUserService userService,
            IOptions<AppSettings> appSettings,
            ILogger<UserController> logger, RequestInfo r)
        {
            this._appSettings = appSettings.Value;
            _userService = userService;
            this._logger = logger;
            _reqinfo = r;
        }
        
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(string userId, string password)
        {
 
            _reqinfo.BranchId = Request.Headers["BranchId"].ToString();
            _reqinfo.DeviceCode = Request.Headers["DeviceCode"].ToString();
            _reqinfo.Init();
            _logger.LogInformation("Validating User " + userId);
            User user = _userService.Validate(userId, password);
            if (user == null)
            {
                _logger.LogError("Given " + userId + " Not found");
                return NotFound(new Exception("Incorrect UserId or Password"));
            }
            if (_reqinfo.DeviceId == "")
            {
                _logger.LogError("Not Authorized computer");
                return NotFound(new Exception("Not Authorized computer"));
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
            user.SessionToken = tokenString;
            user.DeviceId = _reqinfo.DeviceId;
            return Ok(user);
        }
        [AllowAnonymous]
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