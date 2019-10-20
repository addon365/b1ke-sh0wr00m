using addon365.Database.Entity.Permission;
using addon365.IService.Permission;
using Microsoft.AspNetCore.Mvc;

namespace addon365.Web.API.Controllers.Permission
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPermissionController : BaseController<UserPermission>
    {
        public UserPermissionController(IUserPermissionService baseService)
            : base(baseService)
        {
        }
    }
}