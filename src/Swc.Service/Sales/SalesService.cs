using System;
using System.Collections.Generic;
using System.Linq;
using Api.Database.Entity.Threats;
using Api.Domain.Enquiries;
using Threenine.Data;
using Api.Database.Entity.Enquiries;
using Api.Database.Entity;
using Api.Database.Entity.Products;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using Api.Database.Entity.Crm;
using Api.Domain.Sales;
using Api.Database.Entity.Accounts;
using Api.Database.Entity.Finance;
using Api.Database.Entity.Inventory;

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
        public async Task<string> Insert(InsertSalesModel model)
        {
            try
            { 
          
                _unitOfWork.GetRepository<InventoryMaster>().Add(model.Sales);
            _unitOfWork.GetRepository<InventoryInfo>().Add(model.Inventorys);
            _unitOfWork.GetRepository<InventoryItemMaster>().Add(model.itemMasters);
            

            Voucher v = new Voucher();
            foreach(VoucherInfo vi in model.Amounts)
            {
                vi.Voucher = v;
            }
            _unitOfWork.GetRepository<Voucher>().Add(v);
            _unitOfWork.GetRepository<VoucherInfo>().Add(model.Amounts);
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
