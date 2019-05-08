using addon365.Database.Entity.Crm;
using addon365.Database.Service.Base;
using addon365.IService.Crm;
using System;
using System.Collections.Generic;
using System.Text;
using Threenine.Data;

namespace addon365.Database.Service.Crm
{
    public class AppointmentService : BaseService<Appointment>, IAppointmentService
    {
        public AppointmentService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public ICollection<Appointment> FindByStatus(Guid statusId, bool except=false)
        {
            if (except)
                return UnitOfWork.GetRepository<Appointment>().GetList(
                    predicate: appointment => appointment.CurrentStatusId != statusId).Items;
            else
                return UnitOfWork.GetRepository<Appointment>().GetList(
                    predicate: appointment => appointment.CurrentStatusId == statusId).Items;
        }

        public void UpdateStatus(AppointmentStatus appointmentStatus)
        {
            UnitOfWork.GetRepository<AppointmentStatus>().Add(appointmentStatus);
            var appList=UnitOfWork.GetRepository<Appointment>().GetList(
                predicate: appointment => appointment.Id == appointmentStatus.AppointmentId).Items;
            if (appList.Count == 0)
            {
                throw new ArgumentException("Given Appointment not found");
            }
            appList[0].CurrentStatusId = appointmentStatus.Id;
            appList[0].AssignedToId = appointmentStatus.AssignedToId;
            UnitOfWork.GetRepository<Appointment>().Update(appList[0]);
        }
    }
}
