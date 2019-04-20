using System;
using System.Collections.Generic;
using System.Linq;
using addon365.Database.Entity.Threats;
using addon365.Domain.Entity.Bots;
using Threenine.Data;
using AutoMapper;
using addon365.IService;

namespace addon365.Database.Service
{
    public class ReferrerService : IReferrerService
    {
      
        private readonly IUnitOfWork _unitOfWork;
        private const string Enabled = "Enabled";
        private const string Referer = "Referer";
        private const string Moderate = "Moderate";

        public ReferrerService(IUnitOfWork unitOfWork)
        {
           _unitOfWork = unitOfWork;
        }
        public IEnumerable<Referrer> GetAllActive()
        {
            var threats = _unitOfWork.GetRepository<Threat>()
                .GetList().Items.Where(predicate: x => x.Status.Name == Enabled && x.ThreatType.Name == Referer ).AsEnumerable();
          return Mapper.Map<IEnumerable<Referrer>>(source: threats);
          
        }

        public string  Insert(Referrer referrer)
        {
            try
            { 
            // TODO : Move this to a cache lookup.  We don't want to query on every ADD.
            // TODO :  Expected Volumes could be immense to so we need to optimise 
            var refType =_unitOfWork.GetRepository<ThreatType>().GetList().Items.Where(x => x.Name == Referer).SingleOrDefault();
            var status = _unitOfWork.GetRepository<Status>().GetList().Items.Where(x=> x.Name == Moderate).SingleOrDefault();

            var threat = Mapper.Map<Threat>(referrer);

            threat.StatusId =  status.Id;
            threat.TypeId = refType.Id;
            threat.ThreatType = refType;
            threat.Status = status;
           
            _unitOfWork.GetRepository<Threat>().Add(threat);
            _unitOfWork.SaveChanges();

            return threat.Identifier;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public Referrer GetReferer(string identifier)
        {
            var threat = _unitOfWork.GetRepository<Threat>().GetList().Items.Where(x => x.Identifier == identifier).SingleOrDefault();
            return Mapper.Map<Referrer>(threat);
        }
    }
}
