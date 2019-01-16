using System;
using System.Threading.Tasks;
using Api.Database.Entity.Inventory.Purchase;
using Api.Database.Entity.Inventory.Products;
using Api.Domain.Inventory;
using Api.Domain.Paging;
using Microsoft.Extensions.Logging;
using Threenine.Data;
using Threenine.Data.Paging;

namespace Swc.Service.Inventory
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IUnitOfWork _unitOfWork;

        private ILogger<PurchaseService> _Log;
        private RequestInfo _requestInfo;

        public PurchaseService(IUnitOfWork unitOfWork, ILogger<PurchaseService> logger, RequestInfo requestInfo)
        {
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
            throw new NotImplementedException();
        }

        public IPaginate<Purchase> GetAll(PagingParams pagingParams)
        {
            throw new NotImplementedException();
        }

        public PurchaseMasterData GetInitilize()
        {
            PurchaseMasterData masterData = new PurchaseMasterData();
            masterData.Products= _unitOfWork.GetRepository<Product>().GetList(index: 0, size: 1000).Items;

            return masterData;
        }

        public Task<Purchase> Insert(Purchase model)
        {
            throw new NotImplementedException();
        }

        public Task<Purchase> Update(Purchase model)
        {
            throw new NotImplementedException();
        }
    }
}
