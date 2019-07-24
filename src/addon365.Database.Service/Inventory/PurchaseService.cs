using addon365.Database.Entity.Accounts;
using addon365.Database.Entity.Inventory;
using addon365.Database.Entity.Inventory.Catalog;
using addon365.Database.Entity.Inventory.Purchases;
using addon365.Domain.Entity.Inventory;
using addon365.Domain.Entity.Paging;
using addon365.IService.Inventory;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using Threenine.Data;
using Threenine.Data.Paging;

namespace addon365.Database.Service.Inventory
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUnitOfWork<ApiContext> _unitOfTest;

        private ILogger<PurchaseService> _Log;
        private RequestInfo _requestInfo;

        public PurchaseService(IUnitOfWork unitOfWork, IUnitOfWork<ApiContext> unitOfTest, ILogger<PurchaseService> logger, RequestInfo requestInfo)
        {
            _unitOfTest = unitOfTest;
            _unitOfWork = unitOfWork;
            this._Log = logger;
            _requestInfo = requestInfo;
        }
        public Task Delete(string identifier)
        {
            throw new NotImplementedException();
        }

        public Purchase Get(string identifier)
        {
            var Data = _unitOfWork.GetRepository<Purchase>().Single(
                        orderBy: x => x.OrderBy(m => m.Created),
                        predicate: x => x.BranchMasterId.ToString() == _requestInfo.BranchId && x.PurchaseInvoiceNo.ToLower() == identifier.ToLower(),
                        include: x => x.
                        Include(a => a.Seller).ThenInclude(a => a.BusinessContact).
                        Include(a => a.Items).ThenInclude(a => a.Product));

            return Data;
        }

        public IPaginate<Purchase> GetAll(PagingParams pagingParams)
        {
            var data = _unitOfWork.GetRepository<Purchase>().GetList(
                 orderBy: x => x.OrderBy(m => m.Created),
                 include: x => x.
                 Include(a => a.Seller).ThenInclude(a => a.BusinessContact).
                 Include(a => a.Items).ThenInclude(a => a.Product));

            return data;

        }


        public PurchaseMasterData GetInitilize()
        {
            PurchaseMasterData masterData = new PurchaseMasterData();
            masterData.CatalogItems = _unitOfWork.GetRepository<CatalogItem>().GetList(index: 0, size: 1000, include: x => x.Include(n => n.Properties).ThenInclude(m => m.PropertyMaster)).Items;
            masterData.Sellers = _unitOfWork.GetRepository<Seller>().GetList(
               orderBy: x => x.OrderBy(m => m.Created),
               include: x => x.Include(a => a.BusinessContact).ThenInclude(a => a.ContactAddress),
               index: 0, size: 1000).Items;
            masterData.PurchaseBook = _unitOfWork.GetRepository<AccountBook>().Single(predicate: x => x.ProgrammerId == AccountBookEnum.Purchase.ToString());
            masterData.GstBook = _unitOfWork.GetRepository<AccountBook>().Single(predicate: x => x.ProgrammerId == AccountBookEnum.GstBook.ToString());
            masterData.CashBook = _unitOfWork.GetRepository<AccountBook>().Single(predicate: x => x.ProgrammerId == AccountBookEnum.Cash.ToString());
            masterData.VoucherTypeMaster = _unitOfWork.GetRepository<VoucherTypeMaster>().Single(predicate: x => x.ProgrammerId == VoucherTypeMasterEnum.Purchase.ToString());
            return masterData;
        }

        public async Task<Purchase> Insert(Purchase model)
        {
            try
            {
                model.SellerId = model.Seller.Id;
                model.Seller = null;
                foreach (PurchaseItem p in model.Items)
                {
                    p.Product = null;
                    foreach (PurchaseItemPropertyMap ipm in p.ItemPropertyMaps)
                    {
                        foreach (PurchaseItemPropertyValue ipv in ipm.PropertyValues)
                        {
                            ipv.CatalogItemPropertyMaster = null;
                        }
                    }
                }

                _unitOfWork.GetRepository<Purchase>().Add(model);

                _unitOfWork.SaveChanges();
                return _unitOfWork.GetRepository<Purchase>().Single(predicate: x => x.Id == model.Id);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
        }

        public async Task<Purchase> Update(Purchase model)
        {
            _unitOfWork.GetRepository<Purchase>().Update(model);
            _unitOfWork.SaveChanges();
            return _unitOfWork.GetRepository<Purchase>().Single(predicate: x => x.Id == model.Id);
        }
    }
}
