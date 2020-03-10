using addon365.Chit.DataEntity;
using addon365.Chit.DomainEntity;
using addon365.Chit.EfContext;
using addon365.Chit.DataHelper;
using addon365.Crm.DataEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Threenine.Data;

namespace addon365.Chit.EfDataService
{
    public class ChitSubscriberDataService : IChitSubscriberDataService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ChitSubscriberDataService(IUnitOfWork<DatabaseContext> unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public void Delete(Guid KeyId)
        {
            throw new NotImplementedException();
        }
        public ChitSubscriberModel Get(Guid keyId)
        {
            ChitSubscriberTable subscriberTable;
          
            subscriberTable = _unitOfWork.GetRepository<ChitSubscriberTable>().Single(x => x.KeyId == keyId, include: x => x.Include(x => x.Customer).ThenInclude(x => x.Contact).Include(x => x.ChitGroup).Include(x => x.Agent).ThenInclude(x => x.Contact));
            if (subscriberTable != null)
            {


                return new ChitSubscriberModel
                {

                    Customer = new CustomerModel
                    {

                        KeyId = subscriberTable.Customer.KeyId,
                        ContactKeyId=subscriberTable.Customer.ContactKeyId,
                        AccessId = subscriberTable.Customer.AccessId,
                        FirstName = subscriberTable.Customer.Contact.FirstName,
                        LastName = subscriberTable.Customer.Contact.LastName,
                        Place = subscriberTable.Customer.Contact.Place,
                        MobileNo = subscriberTable.Customer.Contact.MobileNumber,
                    },
                    AccessId = subscriberTable.AccessId,
                    KeyId = subscriberTable.KeyId,
                    ChitGroup = new ChitGroupModel
                    {
                        KeyId = subscriberTable.ChitGroup.KeyId,
                        AccessId = subscriberTable.ChitGroup.AccessId,
                        GroupName = subscriberTable.ChitGroup.GroupName,
                        TotalDues = subscriberTable.ChitGroup.TotalDues
                    },

                    Agent = new AgentModel
                    {
                        KeyId = subscriberTable.Agent.KeyId,
                        AccessId = subscriberTable.Agent.AccessId,
                        FirstName = subscriberTable.Agent.Contact.FirstName,
                        LastName = subscriberTable.Agent.Contact.LastName
                    },
                    
                };
            }



            return null;
        }
        public void GetAll()
        {
            _unitOfWork.GetRepository<ChitSchemeTable>().Add(new ChitSchemeTable { KeyId = Guid.NewGuid() });

            _unitOfWork.SaveChanges();
            //var products = _unitOfWork.GetRepository<ChitSchemeModel>().GetList();
        }
        public ChitSubscriberScreenModel GetMasterData()
        {
           
            var Max = _unitOfWork.GetRepository<ChitSubscriberTable>().Single(orderBy: x => x.OrderByDescending(m => Convert.ToInt64(m.AccessId)));
           
            ChitSubscriberScreenModel m = new ChitSubscriberScreenModel();

            if (Max != null)
                m.MaxAccessId = Max.AccessId;
            else
                m.MaxAccessId = "0";


            var CustomerMax = _unitOfWork.GetRepository<CustomerTable>().Single(orderBy: x => x.OrderByDescending(m => Convert.ToInt64(m.AccessId)));
            if (CustomerMax != null)
                m.MaxCustomerAccessId = CustomerMax.AccessId;
            else
                m.MaxCustomerAccessId = "0";

            return m;
        }
        public void Insert(ChitSubscriberModel chitSubscriberModel)
        {

            var contactModel = new ContactTable { KeyId = Guid.NewGuid(), FirstName = chitSubscriberModel.Customer.FirstName, LastName = chitSubscriberModel.Customer.LastName, Place = chitSubscriberModel.Customer.Place, MobileNumber = chitSubscriberModel.Customer.MobileNo };
            var customerModel = new CustomerTable { KeyId = Guid.NewGuid(),AccessId=chitSubscriberModel.Customer.AccessId,ContactKeyId=contactModel.KeyId};
            _unitOfWork.GetRepository<ContactTable>().Add(contactModel);
            _unitOfWork.GetRepository<CustomerTable>().Add(customerModel);

            _unitOfWork.GetRepository<ChitSubscriberTable>().Add(new ChitSubscriberTable { KeyId = Guid.NewGuid(),AccessId=chitSubscriberModel.AccessId,CustomerKeyId=customerModel.KeyId,ChitGroupKeyId=chitSubscriberModel.ChitGroup.KeyId,AgentKeyId=chitSubscriberModel.Agent.KeyId });
            _unitOfWork.SaveChanges();
        }
        public void Update(ChitSubscriberModel chitSubscriberModel)
        {
            
            var contactModel = _unitOfWork.GetRepository<ContactTable>().Single(x => x.KeyId == chitSubscriberModel.Customer.ContactKeyId);
            
            contactModel.FirstName = chitSubscriberModel.Customer.FirstName;
            contactModel.LastName = chitSubscriberModel.Customer.LastName;
            contactModel.Place = chitSubscriberModel.Customer.Place;
            contactModel.MobileNumber = chitSubscriberModel.Customer.MobileNo;

            
            _unitOfWork.GetRepository<ContactTable>().Update(contactModel);

            var customerModel = _unitOfWork.GetRepository<CustomerTable>().Single(x => x.KeyId == chitSubscriberModel.Customer.KeyId);
            customerModel.KeyId = chitSubscriberModel.Customer.KeyId;
            customerModel.AccessId = chitSubscriberModel.Customer.AccessId;
            customerModel.ContactKeyId = contactModel.KeyId;

            _unitOfWork.GetRepository<CustomerTable>().Update(customerModel);

            var chitSubcriberTable= _unitOfWork.GetRepository<ChitSubscriberTable>().Single(x => x.KeyId == chitSubscriberModel.KeyId);
            chitSubcriberTable.KeyId = chitSubscriberModel.KeyId;
            chitSubcriberTable.AccessId = chitSubscriberModel.AccessId;
            chitSubcriberTable.CustomerKeyId = customerModel.KeyId;
            chitSubcriberTable.ChitGroupKeyId = chitSubscriberModel.ChitGroup.KeyId;
            chitSubcriberTable.AgentKeyId = chitSubscriberModel.Agent.KeyId;

            _unitOfWork.GetRepository<ChitSubscriberTable>().Update(chitSubcriberTable);


            _unitOfWork.SaveChanges();
           
        }
        public ChitGroupModel FindGroup(string accessId)
        {
            IChitGroupDataService chitGroupDataService = new ChitGroupDataService((IUnitOfWork<DatabaseContext>)_unitOfWork);
            return chitGroupDataService.Get(accessId);
        }
        public AgentModel FindAgent(string accessId)
        {
            IAgentDataService agentDataService = new AgentDataService((IUnitOfWork<DatabaseContext>)_unitOfWork);
            return agentDataService.Get(accessId);
        }
    }
}
