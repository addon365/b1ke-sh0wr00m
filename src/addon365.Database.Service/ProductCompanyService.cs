using addon365.Database.Entity.Inventory.Catalog;
using addon365.IService;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Threenine.Data;

namespace addon365.Database.Service
{
    public class ProductCompanyService:IProductCompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private const string Enabled = "Enabled";
        private const string Referer = "Referer";
        private const string Moderate = "Moderate";
        public ProductCompanyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<CatalogBrand> GetAllProductCompanies()
        {
            var productcompanies = _unitOfWork.GetRepository<CatalogBrand>().GetList().Items;

            return productcompanies;
        }
        public string Insert(CatalogBrand productcompany)
        {
           
            _unitOfWork.GetRepository<CatalogBrand>().Add(productcompany);
            try
            {
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return productcompany.Identifier;
        }
        public CatalogBrand GetProductCompany(string identifier)
        {
            var productcompany = _unitOfWork.GetRepository<CatalogBrand>().GetList().Items.Where(x => x.Identifier == identifier);
            return Mapper.Map<CatalogBrand>(productcompany);
        }
        public void Delete(CatalogBrand productcompany)
        {
            try
            {

                _unitOfWork.GetRepository<CatalogBrand>().Delete(productcompany.Id);


                _unitOfWork.SaveChanges();

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }
    }
}
