using addon365.Database.Entity.Permission;
using addon365.Database.Service.Base;
using addon365.IService.Permission;
using Threenine.Data;

namespace addon365.Database.Service.Permission
{
    public class RoleGroupService : BaseService<RoleGroupMaster>, IRoleGroupService
    {
        public RoleGroupService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
