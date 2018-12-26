using Api.Database.Entity.Enquiries;
using Api.Domain.Paging;
using System.Threading.Tasks;

namespace Swc.Service
{
    public interface IBookingService
    {
        
        Task Insert(Enquiry model);
        Threenine.Data.Paging.IPaginate<Enquiry> GetAllBooked(PagingParams pagingParams);
        Enquiry GetBooked(string identifier);
    }
}
