using addon365.Database.Entity.Crm;
using addon365.Database.Service.Base;
using addon365.IService.Crm;
using System;
using System.Collections.Generic;
using Threenine.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Threenine.Data;
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
                include: t => t.Include(x => x.Customer)
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
                include: t => t.Include(x => x.Customer)
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
            appointment.CurrentStatusId = appointmentStatus.Id = Guid.NewGuid();
            appointment.CurrentStatus = null;
            appointment.Customer = null;

            UnitOfWork.GetRepository<AppointmentStatus>().Add(appointmentStatus);
            Repository.Update(appointment);

            UnitOfWork.SaveChanges();
            return appointment;
        }

    }
}
