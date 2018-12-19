using Api.Database.Entity.Chit;
using Swc.Service.Base;
using Threenine.Data;

namespace Swc.Service.Chit
{
    public class SchemeService : BaseService<ChitScheme>
    {
        public SchemeService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }
    }
}
