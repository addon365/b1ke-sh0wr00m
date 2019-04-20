using System;
using System.Linq;
using System.Threading.Tasks;
using addon365.Database.Entity.Inventory;
using addon365.Domain.Entity.Paging;
using Microsoft.Extensions.Logging;
using Threenine.Data;
using Threenine.Data.Paging;
using Microsoft.EntityFrameworkCore;
using addon365.IService.Inventory;

namespace addon365.Database.Service.Inventory
{
    public class SellerService : ISellerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private ILogger<SellerService> _looger;
        private RequestInfo _requestInfo;

        public SellerService(IUnitOfWork unitOfWork, ILogger<SellerService> logger, RequestInfo requestInfo)
        {
            _unitOfWork = unitOfWork;
            this._looger = logger;
            _requestInfo = requestInfo;
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Seller Get(string id)
        {
            var model= _unitOfWork.GetRepository<Seller>().GetList(predicate: x => x.SellerId == id);
            if (model.Items.Count == 1)
            {
                return _unitOfWork.GetRepository<Seller>().Single(
                        include: x => x.Include(a => a.BusinessContact).ThenInclude(a => a.ContactAddress));
            }

            throw new Exception("More than one record found");
        }

        public IPaginate<Seller> GetAll(PagingParams pagingParams)
        {
            var Records = _unitOfWork.GetRepository<Seller>().GetList(
               orderBy: x => x.OrderBy(m => m.Created),
               include: x => x.
               Include(a => a.BusinessContact).ThenInclude(a=>a.ContactAddress)
               ,
               index: pagingParams.PageNumber, size: pagingParams.PageSize);



            return Records;
        }

        public async Task<Seller> Insert(Seller model)
        {

            string Id =  "1";
            
            var LastRow = _unitOfWork.GetRepository<Seller>().Single(orderBy: x => x.OrderByDescending(m => Convert.ToInt64(m.SellerId)));


            if (LastRow != null)
            {
                if (LastRow.SellerId != "")
                    Id =  (Convert.ToInt64(LastRow.SellerId) + 1).ToString();
            }

            model.SellerId = Id;

            _unitOfWork.GetRepository<Seller>().Add(model);
            _unitOfWork.SaveChanges();

            return _unitOfWork.GetRepository<Seller>().Single(predicate: x => x.Id == model.Id);
        }

        public async Task<Seller> Update(Seller model)
        {
           
            _unitOfWork.GetRepository<Seller>().Update(model);
            _unitOfWork.SaveChanges();
            
            return _unitOfWork.GetRepository<Seller>().Single(predicate: x => x.Id == model.Id);  
        }
    }
}
