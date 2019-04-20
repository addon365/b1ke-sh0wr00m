using System;
using System.Collections.Generic;
using AutoMapper;
using Threenine.Data;
using System.Linq;
using addon365.Domain.Entity.Paging;
using addon365.Database.Entity.Inventory.Catalog;
using addon365.IService;

namespace addon365.Database.Service
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
        public Threenine.Data.Paging.IPaginate<CatalogItem> GetAllActive(PagingParams pagingParams)
        {
            var products = _unitOfWork.GetRepository<CatalogItem>().GetList(orderBy: x => x.OrderBy(m => m.Created),index: pagingParams.PageNumber, size: pagingParams.PageSize);

            return products;
        }
        public IEnumerable<CatalogItem> GetProductByType(int ProgrammerId)
        {
            var typeid = _unitOfWork.GetRepository<CatalogType>().GetList().Items.Where(y => y.ProgrammerId == ProgrammerId).First<CatalogType>().Id;

         
            var products = _unitOfWork.GetRepository<CatalogItem>().GetList().Items.Where(x=>x.TypeId==typeid);

            return products;
        }
        public string Insert(CatalogItem product)
        {
            //var products = new Product();
            //products.ItemName = product.ItemName;
            //products.Price = product.Price;
            string identi = "1";
            var LastProduct = _unitOfWork.GetRepository<CatalogItem>().Single(orderBy: x => x.OrderByDescending(m => Convert.ToInt64(m.Identifier)));


            if (LastProduct != null)
            {
                if (LastProduct.Identifier !="")
                    identi = (Convert.ToInt64(LastProduct.Identifier)+1).ToString();
            }
            product.Identifier = identi;
            _unitOfWork.GetRepository<CatalogItem>().Add(product);
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
        public string InsertProductType(CatalogType producttype)
        {
            //var products = new Product();
            //products.ItemName = product.ItemName;
            //products.Price = product.Price;
            _unitOfWork.GetRepository<CatalogType>().Add(producttype);
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
        public void Delete(CatalogItem product)
        {
            try { 
                
            _unitOfWork.GetRepository<CatalogItem>().Delete(product.Id);
                
              
            _unitOfWork.SaveChanges();
              
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
            }
        }
        public CatalogItem GetProduct(string identifier)
        {
            var product = _unitOfWork.GetRepository<CatalogItem>().GetList().Items.Where(x => x.Identifier == identifier);
            return Mapper.Map<CatalogItem>(product);
        }
        public IEnumerable<CatalogBrand> GetCompanies()
            {
            var Companies = _unitOfWork.GetRepository<CatalogBrand>().GetList().Items;
            return Companies;
            }
        public IEnumerable<CatalogType> GetTypes()
        {
            var Types = _unitOfWork.GetRepository<CatalogType>().GetList().Items;
            return Types;
        }
    }
}
