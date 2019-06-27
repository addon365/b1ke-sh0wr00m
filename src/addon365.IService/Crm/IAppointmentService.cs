using addon365.Database.Entity.Crm;
using addon365.Database.Entity.Report;
using addon365.Domain.Entity.Crm;
using addon365.IService.Base;
using System;
using System.Collections.Generic;

namespace addon365.IService.Crm
{
    public interface IAppointmentService : IBaseService<Appointment>
    {
        ICollection<AppointmentViewModel> FindByUser(Guid userId);
        IEnumerable<AppointmentViewModel> FindByStatus(Guid userId,Guid satusId);
        Appointment Save(AppointmentViewModel model);

        Appointment Update(Guid id,AppointmentViewModel model);
        IEnumerable<AppointmentViewModel> FindAllVM();
    }
}
