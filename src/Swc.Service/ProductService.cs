using System;
using System.Collections.Generic;
using AutoMapper;
using Threenine.Data;
using System.Linq;
using Api.Domain.Paging;
using Api.Database.Entity.Inventory.Products;

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
        public Threenine.Data.Paging.IPaginate<Product> GetAllActive(PagingParams pagingParams)
        {
            var products = _unitOfWork.GetRepository<Product>().GetList(orderBy: x => x.OrderBy(m => m.Created),index: pagingParams.PageNumber, size: pagingParams.PageSize);

            return products;
        }
        public IEnumerable<Product> GetProductByType(int ProgrammerId)
        {
            var typeid = _unitOfWork.GetRepository<ProductType>().GetList().Items.Where(y => y.ProgrammerId == ProgrammerId).First<ProductType>().Id;

         
            var products = _unitOfWork.GetRepository<Product>().GetList().Items.Where(x=>x.TypeId==typeid);

            return products;
        }
        public string Insert(Product product)
        {
            //var products = new Product();
            //products.ProductName = product.ProductName;
            //products.Price = product.Price;
            string identi = "1";
            var LastProduct = _unitOfWork.GetRepository<Product>().Single(orderBy: x => x.OrderByDescending(m => Convert.ToInt64(m.Identifier)));


            if (LastProduct != null)
            {
                if (LastProduct.Identifier !="")
                    identi = (Convert.ToInt64(LastProduct.Identifier)+1).ToString();
            }
            product.Identifier = identi;
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
        public string InsertProductType(ProductType producttype)
        {
            //var products = new Product();
            //products.ProductName = product.ProductName;
            //products.Price = product.Price;
            _unitOfWork.GetRepository<ProductType>().Add(producttype);
            try
            {
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return producttype.Identifier;
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
            var product = _unitOfWork.GetRepository<Product>().GetList().Items.Where(x => x.Identifier == identifier);
            return Mapper.Map<Product>(product);
        }
        public IEnumerable<ProductCompany> GetCompanies()
            {
            var Companies = _unitOfWork.GetRepository<ProductCompany>().GetList().Items;
            return Companies;
            }
        public IEnumerable<ProductType> GetTypes()
        {
            var Types = _unitOfWork.GetRepository<ProductType>().GetList().Items;
            return Types;
        }
    }
}
