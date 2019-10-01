using System.Net.Http;
using System.Threading.Tasks;

namespace addon365.IService
{
    public interface IValidationService
    {
        Task<HttpResponseMessage> GetServerStatus();
    }
}
