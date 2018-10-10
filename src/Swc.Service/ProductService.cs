using System;
using System.Collections.Generic;
using System.Text;
using Api.Database.Entity.Products;
using Api.Domain.Enquiries;
using AutoMapper;
using Threenine.Data;

namespace Swc.Service
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private const string Enabled = "Enabled";
        private const string Referer = "Referer";
        private const string Moderate = "Moderate";
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Product> GetAllActive()
        {
            var products = _unitOfWork.GetRepository<Product>().Get();

            return products;
        }




        public string Insert(Product product)
        {
            //var products = new Product();
            //products.ProductName = product.ProductName;
            //products.Price = product.Price;
            _unitOfWork.GetRepository<Product>().Add(product);
            try
            {
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return product.Identifier;
        }
        public void Delete(Product product)
        {
            try { 
                
            _unitOfWork.GetRepository<Product>().Delete(product.Id);
                
              
            _unitOfWork.SaveChanges();
              
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
            }
        }
        public Product GetProduct(string identifier)
        {
            var product = _unitOfWork.GetRepository<Product>().Get(x => x.Identifier == identifier);
            return Mapper.Map<Product>(product);
        }
        public IEnumerable<ProductCompany> GetCompanies()
            {
            var Companies = _unitOfWork.GetRepository<ProductCompany>().Get();
            return Companies;
            }
        public IEnumerable<ProductType> GetTypes()
        {
            var Types = _unitOfWork.GetRepository<ProductType>().Get();
            return Types;
        }
    }
}
