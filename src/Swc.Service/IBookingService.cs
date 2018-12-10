using Api.Domain.Booking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Swc.Service
{
    public interface IBookingService
    {
        
        Task Insert(InsertBooking model);
    }
}
