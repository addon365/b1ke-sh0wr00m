using System;
using System.Collections.Generic;
using System.Text;

namespace addon365.Database.Service
{
    public class Queries
    {
        public static string AppointmentStatusQuery = @"
                    SELECT  a.Id,lu.UserName as 'LeadName' , a.AppointmentDate,
                    sm.StatusName as 'Status', aStatus.DueDate, au.UserName as 'AssignedTo', 
					aStatus.Comments
					FROM addon.Appointments a
                    INNER JOIN addon.AppointmentStatuses  aStatus ON a.Id=aStatus.AppointmentId 
                    INNER JOIN addon.Users au ON au.Id=aStatus.AssignedToId
                    INNER JOIN addon.Leads l ON l.Id= a.LeadId
                    INNER JOIN addon.Users lu ON l.UserId=lu.Id
                    INNER JOIN addon.StatusMasters sm on sm.Id=aStatus.StatusId
                    ORDER BY aStatus.UpdatedDate DESC;";
    }
}
