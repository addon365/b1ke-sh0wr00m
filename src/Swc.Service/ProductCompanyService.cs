using Api.Database.Entity.Inventory.Products;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Threenine.Data;

namespace Swc.Service
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
        public IEnumerable<ProductCompany> GetAllProductCompanies()
        {
            var productcompanies = _unitOfWork.GetRepository<ProductCompany>().GetList().Items;

            return productcompanies;
        }
        public string Insert(ProductCompany productcompany)
        {
           
            _unitOfWork.GetRepository<ProductCompany>().Add(productcompany);
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
        public ProductCompany GetProductCompany(string identifier)
        {
            var productcompany = _unitOfWork.GetRepository<ProductCompany>().GetList().Items.Where(x => x.Identifier == identifier);
            return Mapper.Map<ProductCompany>(productcompany);
        }
        public void Delete(ProductCompany productcompany)
        {
            try
            {

                _unitOfWork.GetRepository<ProductCompany>().Delete(productcompany.Id);


                _unitOfWork.SaveChanges();

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }
    }
}
