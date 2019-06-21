﻿using addon365.Database.Entity.Crm;
using addon365.Database.Entity.Report;
using addon365.IService.Base;
using System;
using System.Collections.Generic;

namespace addon365.IService.Crm
{
    public interface IAppointmentService : IBaseService<Appointment>
    {
        ICollection<Appointment> FindByUser(Guid userId);
        IEnumerable<Appointment> FindByStatus(Guid satusId);

    }
}