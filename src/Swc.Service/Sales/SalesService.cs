using System;
using Threenine.Data;
using Api.Database.Entity;
using System.Threading.Tasks;
using Api.Domain.Sales;
using Api.Database.Entity.Accounts;
using Api.Database.Entity.Finance;
using Api.Database.Entity.Inventory.Sales;
using Api.Database.Entity.Inventory.Products;

namespace Swc.Service.Sales
{
    public class SalesService : ISalesService
    {
      
        private readonly IUnitOfWork _unitOfWork;
       

        public SalesService(IUnitOfWork unitOfWork)
        {
           _unitOfWork = unitOfWork;
        }
     
        public InitilizeSales GetInitilizeSales()
        {
            InitilizeSales ie = new InitilizeSales();
            ie.MarketingZones = _unitOfWork.GetRepository<MarketingZone>().GetList().Items;
            ie.Products = _unitOfWork.GetRepository<Product>().GetList().Items;
            ie.PaymentModes = _unitOfWork.GetRepository<PaymentMode>().GetList().Items;
            ie.FinanceCompanies = _unitOfWork.GetRepository<FinanceCompany>().GetList().Items;

            return ie;

        }
        public async Task<string> Insert(Sale model)
        {
            try
            { 
          
            _unitOfWork.GetRepository<Sale>().Add(model);
            

         
            _unitOfWork.SaveChanges();
      
           
            }
            catch(Exception ex)
            {
                string str = ex.Message;
            }
            return "";

        }


    }
}
