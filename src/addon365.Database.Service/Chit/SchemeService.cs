using addon365.Database.Entity.Chit;
using addon365.Database.Service.Base;
using addon365.IService.Chit;
using Threenine.Data;

namespace addon365.Database.Service.Chit
{
    public class SchemeService : BaseService<ChitScheme>,ISchemeService
    {
       
        public SchemeService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            
        }

       
    }
}
