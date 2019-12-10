using addon365.Database.Entity.Permission;
using addon365.Database.Entity.Users;
using addon365.Database.Service;
using addon365.IService;
using addon365.Web.API.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace addon365.Web.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
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


        [HttpPut("token")]
        public IActionResult UpdateToken([FromForm] Guid id, [FromForm] string token)
        {
            User user = _userService.UpdateToken(id, token);
            if (user == null)
                return BadRequest("Cannot find user");
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(string userId, string password)
        {
            //String userId = paramUser.UserId;
            //String password = paramUser.Password;
            _reqinfo.BranchId = Request.Headers["BranchId"].ToString();
            _reqinfo.DeviceCode = Request.Headers["DeviceCode"].ToString();
            string requestedBy = Request.Headers["requestedBy"].ToString();
            _logger.LogInformation("Validating User " + userId);
            User user = _userService.Validate(userId, password);
            if (user == null)
            {
                _logger.LogError("Given " + userId + " Not found");
                return NotFound(new Exception("Incorrect UserId or Password"));
            }
            //_reqinfo.Init(userId);
            //if (_reqinfo.DeviceId == "")
            //{
            //    _logger.LogError("Not Authorized computer");
            //    return NotFound(new Exception("Not Authorized computer"));
            //}

            _logger.LogInformation("Given User " + userId + " Found");
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
            User currentUser = _userService.Find(user.Id);
            var permission = new { logicName = "all", create = true, edit = true, update = true, delete = true };
            if (String.Compare(currentUser.RoleGroup.Name, "root", StringComparison.OrdinalIgnoreCase) != 0)
            {
                permission = new { logicName = "marketing", create = true, edit = true, update = true, delete = false };
            }


            if (String.Compare(requestedBy, "mobile", StringComparison.OrdinalIgnoreCase) != 0)
            {
                return Ok(currentUser);
            }


            var resultData = new { id = currentUser.Id, userId = currentUser.UserId, userName = currentUser.UserName, roleGroup = currentUser.RoleGroup, permission = permission };
            return Ok(resultData);
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetUsers()
        {
            if (!_userService.GetUsers().Any())
                _logger.LogWarning("No users found");
            return Ok(_userService.GetUsers());
        }
        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            User createdUser = _userService.InsertUser(user);
            if (createdUser == null)
            {
                _logger.LogError("User already exists");
                return StatusCode(StatusCodes.Status409Conflict, "User Already Exists");
            }
            return Ok(createdUser);
        }

        [HttpPut("changePassword/{id}")]
        public IActionResult ChangePassword(Guid id, [FromForm]string oldPassword, [FromForm]string newPassword)
        {
            string errorMessage = _userService.ChangePassword(id, oldPassword, newPassword);
            if (errorMessage != null)
            {
                return BadRequest(errorMessage);
            }
            else
            {
                return Ok("Password Changed Succcessfully");
            }
        }

    }
}