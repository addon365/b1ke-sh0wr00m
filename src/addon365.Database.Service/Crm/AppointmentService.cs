using addon365.Database.Entity.Crm;
using addon365.Database.Service.Base;
using addon365.IService.Crm;
using System;
using System.Collections.Generic;
using Threenine.Data;
using Microsoft.EntityFrameworkCore;
using addon365.Domain.Entity.Crm;
using System.Linq;
using addon365.Database.Entity.Report;

namespace addon365.Database.Service.Crm
{
    public class AppointmentService : BaseService<Appointment>, IAppointmentService
    {
        public AppointmentService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public ICollection<Appointment> FindByUser(Guid userId)
        {
            var statusId = UnitOfWork.GetRepository<StatusMaster>()
                .GetList(predicate: x => x.StatusName == "Closed")
                .Items[0].Id;

            return UnitOfWork.GetRepository<Appointment>().GetList(
                predicate: appointment =>
                appointment.CurrentStatus.AssignedToId == userId &&
                appointment.CurrentStatus.Status.StatusName != "Closed",
                include: t => t.Include(x => x.Lead)
                .ThenInclude(x => x.User)
                .Include(x => x.CurrentStatus)
                .ThenInclude(x => x.AssignedTo)
                .Include(x => x.CurrentStatus)
                .ThenInclude(x => x.UpdatedBy)
                .Include(x => x.CurrentStatus)
                .ThenInclude(x => x.Status)
                ).Items;

        }
        public override IEnumerable<Appointment> FindAll()
        {
            return Repository.GetList(
                include: t => t.Include(x => x.Lead)
                .ThenInclude(x => x.User)
                .Include(x => x.CurrentStatus)
                .ThenInclude(x => x.AssignedTo)
                .Include(x => x.CurrentStatus)
                .ThenInclude(x => x.UpdatedBy)
                .Include(x => x.CurrentStatus)
                .ThenInclude(x => x.Status)
                    ).Items;
        }



        public override Appointment Update(Guid id, Appointment inAppointment)
        {
            var outAppointment= Repository.GetList(predicate: x => x.Id == inAppointment.Id).Items[0];
            AppointmentStatus appointmentStatus = inAppointment.CurrentStatus;
            appointmentStatus.Id = Guid.NewGuid();

            outAppointment.CurrentStatus = appointmentStatus;
            outAppointment.Lead = null;
            appointmentStatus.AssignedTo = null;
            appointmentStatus.Status = null;
            appointmentStatus.AppointmentId = outAppointment.Id;
            UnitOfWork.GetRepository<AppointmentStatus>().Add(appointmentStatus);

            Repository.Update(outAppointment);

            UnitOfWork.SaveChanges();
            return inAppointment;
        }

        public IEnumerable<Appointment> FindByStatus(Guid statusId)
        {

            return UnitOfWork.GetRepository<Appointment>().GetList(
                 predicate: appointment =>
                 appointment.CurrentStatus.Status.Id == statusId,
                 include: t => t.Include(x => x.Lead)
                 .ThenInclude(x => x.User)
                 .Include(x => x.CurrentStatus)
                 .ThenInclude(x => x.AssignedTo)
                 .Include(x => x.CurrentStatus)
                 .ThenInclude(x => x.UpdatedBy)
                 .Include(x => x.CurrentStatus)
                 .ThenInclude(x => x.Status)
                 ).Items;
        }
    }
}
