using addon365.Database.Entity.Crm;
using addon365.IService.Base;
using System;
using System.Collections.Generic;

namespace addon365.IService.Crm
{
    public interface IAppointmentService : IBaseService<Appointment>
    {
        ICollection<Appointment> FindByStatus(Guid statusId,bool except=false);
        void UpdateStatus(AppointmentStatus appointmentStatus);
    }
}
