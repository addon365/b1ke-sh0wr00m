using addon365.Database.Entity.Enquiries;
using addon365.Domain.Entity.Paging;
using System.Threading.Tasks;

namespace addon365.IService
{
    public interface IBookingService
    {

        Task Insert(Enquiry model);
        Threenine.Data.Paging.IPaginate<Enquiry> GetAllBooked(PagingParams pagingParams);
        Enquiry GetBooked(string identifier);
    }
}
