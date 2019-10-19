using addon365.WebClient.Service.BaseService;
using addon365.Database.Entity.Chit;
using addon365.Database.Service.Chit;
using addon365.IService.Chit;

namespace addon365.WebClient.Service.WebService.Chit
{
    public class SchemeService : BaseClientService<ChitScheme>, ISchemeService
    {
        public override string getUrl()
        {
            return "Scheme";
        }
    }
}
