using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using addon365.Chit.DataEntity;
using addon365.Chit.DomainEntity;
using addon365.Chit.EfContext;
using addon365.Chit.DataHelper;
using addon365.Common.DataHelper;
using addon365.Crm.DataEntity;
using Microsoft.EntityFrameworkCore;
using Threenine.Data;

namespace addon365.Chit.EfDataService
{
    public class AgentDataService :IAgentDataService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AgentDataService(IUnitOfWork<DatabaseContext> unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public void Delete(Guid KeyId)
        {
            throw new NotImplementedException();
        }

        public AgentModel Get(Guid keyId)
        {
            AgentTable agentTable;

            agentTable = _unitOfWork.GetRepository<AgentTable>().Single(x => x.KeyId == keyId, include: x => x.Include(x => x.Contact));
            if (agentTable != null)
            {
                return ConvertTo(agentTable);
            }
            return null;
        }
        public AgentModel Get(string accessId)
        {
            AgentTable agentTable;

            agentTable = _unitOfWork.GetRepository<AgentTable>().Single(x => x.AccessId==accessId, include: x => x.Include(x => x.Contact));
            if (agentTable != null)
            {


                return ConvertTo(agentTable);

            }
            return null;
        }
        private AgentModel ConvertTo(AgentTable agentTable)
        {

            return new AgentModel
            {
                KeyId = agentTable.KeyId,
                AccessId = agentTable.AccessId,
                FirstName = agentTable.Contact.FirstName,
                LastName = agentTable.Contact.LastName
            };
        }
        public void GetAll()
        {
            throw new NotImplementedException();
        }



     


        public AgentMasterModel GetMasterData()
        {
            var Max = _unitOfWork.GetRepository<AgentTable>().Single(orderBy: x => x.OrderByDescending(m => Convert.ToInt64(m.AccessId)));
            AgentMasterModel m = new AgentMasterModel();
            if (Max != null)
                m.MaxAccessId = Max.AccessId;
            else
                m.MaxAccessId = "0";

            return m;
        }

        public void Insert(AgentModel domainModel)
        {
            var contact = new ContactTable { KeyId = Guid.NewGuid(), FirstName = domainModel.FirstName, LastName = domainModel.LastName };
            _unitOfWork.GetRepository<ContactTable>().Add(contact);
            _unitOfWork.GetRepository<AgentTable>().Add(new AgentTable { KeyId = Guid.NewGuid(), AccessId = domainModel.AccessId,ContactId= contact.KeyId });
            _unitOfWork.SaveChanges();
        }

        public void Update(AgentModel domainModel)
        {
            

            var agentTable = _unitOfWork.GetRepository<AgentTable>().Single(x => x.KeyId == domainModel.KeyId);

            agentTable.AccessId = domainModel.AccessId;

            _unitOfWork.GetRepository<AgentTable>().Update(agentTable);

            var contactTable = _unitOfWork.GetRepository<ContactTable>().Single(x => x.KeyId == agentTable.ContactId);

            contactTable.FirstName = domainModel.FirstName;
            contactTable.LastName = domainModel.LastName;

            _unitOfWork.GetRepository<ContactTable>().Update(contactTable);


            _unitOfWork.SaveChanges();
        }

       
    }
}
