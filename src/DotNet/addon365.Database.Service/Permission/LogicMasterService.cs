using addon365.Database.Entity.Permission;
using addon365.Database.Service.Base;
using addon365.IService.Permission;
using Threenine.Data;

namespace addon365.Database.Service.Permission
{
    public class LogicMasterService : BaseService<LogicMaster>,ILogicMasterService
    {
        public LogicMasterService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
