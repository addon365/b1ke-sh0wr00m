using addon365.Database.Entity.Crm;
using addon365.Database.Service.Base;
using addon365.Database.Service.Util;
using addon365.Domain.Entity.Crm;
using addon365.IService.Crm;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threenine.Data;

namespace addon365.Database.Service.Crm
{
    public class AppointmentService : BaseService<Appointment>, IAppointmentService
    {
        ApiContext CrmContext { get; set; }
        public AppointmentService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            CrmContext = ((UnitOfWork<ApiContext>)unitOfWork).Context;
        }
        public override IEnumerable<Appointment> FindAll()
        {
            DbSet<Appointment> appDbSet = CrmContext.Appointments;
            DbSet<AppointmentStatus> appStatusDbSet = CrmContext.AppointmentStatuses;

            return appDbSet.Include(x => x.AppointmentStatuses)
                 .OrderByDescending(t => t.AppointmentStatuses.Select(x => x.Order))
                 .ToList();
        }
        public ICollection<AppointmentViewModel> FindByUser(Guid userId)
        {

            DbSet<Appointment> appDb = CrmContext.Appointments;
            DbSet<AppointmentStatus> appStatusDb = CrmContext.AppointmentStatuses;
            var result = appDb
                .Include(x => x.Lead)
                .ThenInclude(l => l.Contact)
                .Include(x => x.AppointmentStatuses)
                .ThenInclude(x => x.Status)
                .Include(x => x.AppointmentStatuses)
                .ThenInclude(x => x.AssignedTo)
                .Where(x => x.AppointmentStatuses.OrderByDescending(xl => xl.Order)
                .First().AssignedToId == userId).ToList();

            return this.ToViewModel(result);




        }
        public IEnumerable<AppointmentViewModel> FindAllVM()
        {
            var appointments = Repository.GetList(
                include:
                 x =>
                 x.Include(t => t.Lead)
                 .ThenInclude(l => l.Contact)
                 .Include(t => t.AppointmentStatuses)

                 .ThenInclude(t => t.AssignedTo)
                 .Include(t => t.AppointmentStatuses)
                 .ThenInclude(t => t.Status)

             ).Items;
            return ToViewModel(appointments);

        }


        public IEnumerable<AppointmentViewModel> FindByStatus(Guid userId, Guid statusId)
        {

            var appointments = Repository.GetList(
                predicate: x =>
                (userId == Guid.Empty ? true :
                x.AppointmentStatuses
            .OrderByDescending(r => r.Order).ToList()[0].AssignedToId == userId)
            && x.AppointmentStatuses
           .OrderByDescending(r => r.Order).ToList()[0].StatusId == statusId,

                include:
                 x =>
                 x.Include(t => t.Lead)
                 .ThenInclude(l => l.Contact)
                 .Include(t => t.AppointmentStatuses)

                 .ThenInclude(t => t.AssignedTo)
                 .Include(t => t.AppointmentStatuses)
                 .ThenInclude(t => t.Status)

             ).Items;
            return ToViewModel(appointments);
        }




        public Appointment Update(Guid id, AppointmentViewModel model)
        {
            var outAppointment = Repository.GetList(predicate: x =>
             x.Id == model.Id,
             include: x => x.Include(t => t.AppointmentStatuses)
            ).Items[0];

            var appStatus = outAppointment.AppointmentStatuses
                .OrderByDescending(x => x.Order).FirstOrDefault();

            bool sendNotification = model.AssignedToId != null &&
                appStatus.AssignedToId != model.AssignedToId;

            AppointmentStatus appointmentStatus = new AppointmentStatus
            {
                Id = Guid.NewGuid(),
                DueDate = model.DueDate,
                AssignedToId = model.AssignedToId,
                Comments = model.Comments,
                Modified = DateTime.Now,
                StatusId = model.StatusId,
                UpdatedById = model.UpdatedById,
                UpdatedDate = DateTime.Now,
                Order = outAppointment.AppointmentStatuses.Count

            };


            var result = CrmContext.Appointments.Include(x => x.AppointmentStatuses)
                .AsNoTracking()
                .SingleOrDefault(x => x.Id == model.Id);
            CrmContext.Attach(result);
            result.AppointmentStatuses.Add(appointmentStatus);

            CrmContext.SaveChanges();

            if (sendNotification)
            {
                //UserService service = new UserService(UnitOfWork);
                //string token = service.GetToken((Guid)model.AssignedToId);
                //NotificationService.SendNotification(token, "Appointment Assigned",
                //    "Appointment reassigned to  you", data: new Dictionary<string, string>(){
                //        {"type","Appointment" },
                //        {"id",id.ToString() }
                //});
            }

            return Find(outAppointment.Id);
        }

        Appointment IAppointmentService.Save(AppointmentViewModel model)
        {

            List<AppointmentStatus> statues = new List<AppointmentStatus>();
            AppointmentStatus status = new AppointmentStatus
            {
                Id = Guid.NewGuid(),
                Comments = model.Comments,
                AssignedToId = model.AssignedToId,
                DueDate = model.DueDate,
                Created = DateTime.Now,
                Modified = DateTime.Now,
                StatusId = model.StatusId,
                UpdatedById = model.UpdatedById,
                UpdatedDate = DateTime.Now,
                Order = 0
            };
            statues.Add(status);
            Appointment appointment = new Appointment
            {
                Id = Guid.NewGuid(),
                AppointmentDate = model.AppointmentDate,
                LeadId = model.LeadId,
                Lead = null,
                Created = DateTime.Now,
                AppointmentStatuses = statues,

            };
            Repository.Add(appointment);
            UnitOfWork.SaveChanges();
            return Find(appointment.Id);
        }

        #region Helper Methods
        private List<AppointmentViewModel> ToViewModel(IList<Appointment> appointments)
        {
            List<AppointmentViewModel> appointmentViewModels
                = new List<AppointmentViewModel>();
            foreach (Appointment x in appointments)
            {
                var orderStatues = x.AppointmentStatuses
                     .OrderByDescending(r => r.Order)
                     .ToList();
                appointmentViewModels.Add(new AppointmentViewModel
                {

                    AppointmentDate = x.AppointmentDate,
                    Id = x.Id,
                    LeadId = x.LeadId,
                    LeadName = x.Lead.Contact.BusinessName,
                    Comments = orderStatues[0].Comments,
                    DueDate = orderStatues[0].DueDate,
                    StatusId = orderStatues[0].StatusId,
                    UpdatedById = orderStatues[0].UpdatedById,
                    AssignedToId = orderStatues[0].AssignedToId,
                    AssignedTo = orderStatues[0].AssignedTo.UserName,
                    Status = orderStatues[0].Status.StatusName,
                    PreviousStatus = orderStatues.Count <= 1 ? "" :
                                     orderStatues[1].Status.StatusName,
                });
            }

            return appointmentViewModels;
        }
        private bool Predicate(Appointment x, Guid userId, Guid statusId)
        {
            bool bUser = userId == null ? true : x.AppointmentStatuses
            .OrderByDescending(r => r.Order).ToList()[0].AssignedToId == userId;
            bool bStatus = x.AppointmentStatuses
           .OrderByDescending(r => r.Order).ToList()[0].StatusId == statusId;
            return bUser && bStatus;
        }
        #endregion


    //    private Task<string> SendNotification(string token,
    //      string title, string messageBody, IReadOnlyDictionary<string, string> data)
    //    {
    //        // This registration token comes from the client FCM SDKs.
    //        var registrationToken = token;

    //        // See documentation on defining a message payload.
    //        var message = new Message()
    //        {
    //            Notification = new Notification()
    //            {
    //                Title = title,
    //                Body = messageBody
    //            },
    //            Data = data,
    //            Token = registrationToken,
    //        };

    //        // Send a message to the device corresponding to the provided
    //        // registration token.


    //        // Response is a message ID string.
    //        return
    //        FirebaseMessaging.DefaultInstance.SendAsync(message);
    //    }
    }
}
