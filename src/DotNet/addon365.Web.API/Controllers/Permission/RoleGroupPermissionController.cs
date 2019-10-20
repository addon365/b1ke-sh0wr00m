using addon365.Database.Entity.Permission;
using addon365.IService.Permission;

namespace addon365.Web.API.Controllers.Permission
{
    public class RoleGroupPermissionController : BaseController<RoleGroupPermission>
    {
        public RoleGroupPermissionController(IRoleGroupPermissionService baseService)
            : base(baseService)
        {
        }
    }
}