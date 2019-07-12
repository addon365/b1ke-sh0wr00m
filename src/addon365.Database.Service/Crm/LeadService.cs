using addon365.Database.Entity.Crm;
using addon365.Database.Service.Base;
using addon365.IService.Crm;
using System.Collections.Generic;
using Threenine.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using addon365.Domain.Entity.Crm;
using Newtonsoft.Json;
using System;

namespace addon365.Database.Service.Crm
{
    public class LeadService : BaseService<Lead>,
        ILeadService
    {
        ApiContext CrmContext { get; set; }
        public LeadService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            CrmContext = ((UnitOfWork<ApiContext>)unitOfWork).Context;
        }

        public override Lead Find(Guid id)
        {
            var items = Repository.GetList(
                predicate: i => i.Id == id,
                include: x => x.Include(c => c.Contact)
                .ThenInclude(ct => ct.ContactAddress)
                .Include(c => c.Contact)
                .ThenInclude(ct => ct.Proprietor)
                .Include(c => c.Contact)
                .ThenInclude(ct => ct.ContactPerson)
                .Include(t => t.Source)
                .Include(t => t.History)
                .ThenInclude(t => t.Status)
                ).Items;
            if (items.Count == 0)
                return null;
            var item = items[0];
            var orderedList = item.History.OrderByDescending(x => x.Order);
            item.History = orderedList.ToArray();
            return item;
        }

        public override Lead Save(Lead obj)
        {
            if (FindByMobile(obj.Contact.MobileNumber,
                obj.Contact.Landline) != null)
                return null;

            Repository.Add(obj);
            UnitOfWork.SaveChanges();
            return obj;
        }

        public override Lead Update(Guid id, Lead lead)
        {
            var foundLead = CrmContext.Leads.Include(x => x.History)
                .AsNoTracking()
                .SingleOrDefault(x => x.Id == id);

            if (foundLead == null)
                return null;

            var aHistory = lead.History[0];
            aHistory.Id = Guid.NewGuid();
            aHistory.StatusDate = DateTime.Now;
            aHistory.Status = null;
            aHistory.Order = foundLead.History.Count;
            CrmContext.Leads.Attach(foundLead);
            foundLead.History.Add(aHistory);
            //CrmContext.Entry(foundLead).State = EntityState.Modified;
            
            CrmContext.SaveChanges();

            return CrmContext.Leads.Include(x => x.History)
                .AsNoTracking()
                .SingleOrDefault(x => x.Id == id);
        }
        public override IEnumerable<Lead> FindAll()
        {
            return Repository.GetList(
                include: item => item.Include(c => c.Contact)
                .ThenInclude(ct => ct.ContactAddress)
                .Include(c => c.Contact)
                .ThenInclude(ct => ct.Proprietor)
                .Include(c => c.Contact)
                .ThenInclude(ct => ct.ContactPerson)
                .Include(t => t.Source)
                .Include(t => t.History)
                .ThenInclude(x => x.Status)



                ).Items;
        }

        public Lead FindByMobile(string mobileNumber, string landline)
        {
            var list = Repository.GetList(predicate:
               c => c.Contact.MobileNumber.CompareTo(mobileNumber) == 0
               || c.Contact.Landline.CompareTo(landline) == 0,
               include: x => x.Include(bc => bc.Contact));
            if (list.Count > 0)
                return list.Items[0];
            return null;
        }

        public List<LeadViewModel> FindLeads()
        {
            var dbLeads = CrmContext.Leads;
            var dbLeadHistory = CrmContext.LeadHistory;

            return dbLeads.Join(
                 dbLeadHistory,
                 l => l.CurrentLeadStatusId,
                 h => h.Id,
                 (l, h) =>
                     new LeadViewModel
                     {
                         Id = l.Id,
                         CompanyName = l.Contact.BusinessName,
                         StatusName = h.Status.Name,
                         ExtraData = h.ExtraData
                     }
                 ).ToList();

        }
    }
}
