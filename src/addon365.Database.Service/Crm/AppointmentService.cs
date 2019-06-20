using addon365.Database.Entity.Crm;
using addon365.Database.Service.Base;
using addon365.IService.Crm;
using System;
using System.Collections.Generic;
using Threenine.Data;
using Microsoft.EntityFrameworkCore;
using addon365.Domain.Entity.Crm;
using System.Linq;
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



        public override Appointment Update(Guid id, Appointment appointment)
        {

            AppointmentStatus appointmentStatus = appointment.CurrentStatus;
            appointmentStatus.Id = Guid.NewGuid();
            appointment.CurrentStatus = appointmentStatus;
            appointment.Lead = null;
            appointmentStatus.AssignedTo = null;
            appointmentStatus.Status = null;
            appointmentStatus.AppointmentId = appointment.Id;
            UnitOfWork.GetRepository<AppointmentStatus>().Add(appointmentStatus);

            Repository.Update(appointment);

            UnitOfWork.SaveChanges();
            return appointment;
        }

        public IEnumerable<AppointmentViewModel> FindByStatus(string statusName)
        {
            var appointmentsByStatus = Repository.GetList(
                  predicate: a => a.CurrentStatus.Status.StatusName.CompareTo(statusName) == 0,
                  include: x => x.Include(t => t.CurrentStatus)
                   .ThenInclude(t => t.Status)
                   .Include(t => t.CurrentStatus)
                   .ThenInclude(t => t.AssignedTo)
                   .Include(t => t.Lead)
                   .ThenInclude(t => t.User)
                   ).Items;

            var appointmentsStatus = UnitOfWork.GetRepository<AppointmentStatus>().GetList().Items;


            var appointments = new List<AppointmentViewModel>();
            for (int i = 0; i < appointmentsByStatus.Count; i++)
            {
                var currentAppointment = appointmentsByStatus.ElementAt(i);
                var currentStatus = currentAppointment.CurrentStatus.Status;
                var result = UnitOfWork.GetRepository<AppointmentStatus>()
                    .GetList(predicate: x => x.AppointmentId == appointmentsByStatus[i].Id,
                    include: s => s.Include(x => x.Status)
                   ).Items;
                var resultDesc = result.OrderByDescending(x => x.Modified);
                string previousStatus = null;
                if (currentStatus.Priority.CompareTo("Minor") == 0
                    && resultDesc.Count() > 2)
                {
                    previousStatus = resultDesc.ElementAt(1).Status.StatusName;
                }

                var appointment = new AppointmentViewModel
                {
                    Id = currentAppointment.Id,
                    AppointmentDate = currentAppointment.AppointmentDate,
                    AssignedTo = currentAppointment.CurrentStatus.AssignedTo.UserName,
                    Comments = currentAppointment.CurrentStatus.Comments,
                    DueDate = currentAppointment.CurrentStatus.DueDate,
                    LeadName = currentAppointment.Lead.User.UserName,
                    PreviousStatus = previousStatus,
                    Status = currentAppointment.CurrentStatus.Status.StatusName
                };
                appointments.Add(appointment);
            }
            return appointments;
        }
    }
}
