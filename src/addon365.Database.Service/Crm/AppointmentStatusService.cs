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
            var reuslt= base.Save(appointmentStatus);
            UnitOfWork.GetRepository<AppointmentStatus>().Add(appointmentStatus);
            var appList = UnitOfWork.GetRepository<Appointment>().GetList(
                predicate: aAppointment => aAppointment.Id == appointmentStatus.AppointmentId).Items;
            if (appList.Count == 0)
            {
                throw new ArgumentException("Given Appointment not found");
            }
            Appointment appointment = appList[0];
            appointment.CurrentStatusId = appointmentStatus.Id;
            UnitOfWork.GetRepository<Appointment>().Update(appointment);
            UnitOfWork.SaveChanges();
            return appointmentStatus;
        }

    }
}
