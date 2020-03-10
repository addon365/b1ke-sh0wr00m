using addon365.Chit.Context.Ef;
using addon365.Chit.DataEntity;
using addon365.Chit.DomainEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Threenine.Data;

namespace addon365.Chit.DataService.Ef
{
    public class AgentListDataService : IAgentListDataService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AgentListDataService(IUnitOfWork<DatabaseContext> unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public void Delete(Guid KeyId)
        {

            //var agent = _unitOfWork.GetRepository<AgentTable>().Single(x => x.KeyId == KeyId);
            _unitOfWork.GetRepository<AgentTable>().Delete(KeyId);
            _unitOfWork.SaveChanges();

        }

        public void Edit(Guid KeyId)
        {
            throw new NotImplementedException();
        }

        public IList<AgentModel> GetAll()
        {
            IList<AgentModel> lst = new List<AgentModel>();
            foreach(AgentTable agentTable in _unitOfWork.GetRepository<AgentTable>().GetList(orderBy: x => x.OrderBy(x => Convert.ToInt32(x.AccessId)), include: x => x.Include(x => x.Contact), index: 0, size: 5000).Items)
            {
                lst.Add(new AgentModel {KeyId=agentTable.KeyId,AccessId=agentTable.AccessId, FirstName = agentTable.Contact.FirstName, LastName = agentTable.Contact.LastName });
            }

            return lst;
        }

    }
}
