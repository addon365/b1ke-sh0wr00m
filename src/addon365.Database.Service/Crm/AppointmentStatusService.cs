using addon365.Database.Entity.Crm;
using addon365.Database.Service.Base;
using addon365.IService.Crm;
using System;
using System.Collections.Generic;
using System.Text;
using Threenine.Data;

namespace addon365.Database.Service.Crm
{
    public class AppointmentStatusService : BaseService<AppointmentStatus>, IAppointmentStatusService
    {
        public AppointmentStatusService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override AppointmentStatus Save(AppointmentStatus appointmentStatus)
        {
            return null;
        }

    }
}
