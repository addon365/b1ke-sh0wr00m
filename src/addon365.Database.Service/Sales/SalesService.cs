using System;
using Threenine.Data;
using addon365.Database.Entity;
using System.Threading.Tasks;
using addon365.Domain.Entity.Sales;
using addon365.Database.Entity.Accounts;
using addon365.Database.Entity.Finance;
using addon365.Database.Entity.Inventory.Sales;
using addon365.Database.Entity.Inventory.Catalog;

namespace addon365.Database.Service.Sales
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
            ie.CatalogItems = _unitOfWork.GetRepository<CatalogItem>().GetList().Items;
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
