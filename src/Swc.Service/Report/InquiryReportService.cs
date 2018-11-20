using Api.Database.Entity.Enquiries;
using Api.Database.Entity.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Threenine.Data;

namespace Swc.Service.Report
{
    /// <summary>
    /// Implementation to serve Inquiry reports in different formats.
    /// </summary>
    public class InquiryReportService : IInquiryReportService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InquiryReportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<KeyValuePair<string, int>> GetBasedOnProduct(DateTime fromDate,
            DateTime toDate)
        {
            var enquiries = _unitOfWork.GetReadOnlyRepository<Enquiry>().GetList().Items;

            IList<EnquiryProduct> listOfEnquiryProduct = new List<EnquiryProduct>();
            foreach (Enquiry enquiry in enquiries)
            {
                var products = _unitOfWork.GetRepository<EnquiryProduct>()
                    .GetList(predicate: p => p.EnquiryId == enquiry.Id).Items;
                foreach (EnquiryProduct product in products)
                    listOfEnquiryProduct.Add(product);

            }

            var listOfProduct = new List<Product>();
            foreach (EnquiryProduct enquiryProduct in listOfEnquiryProduct)
            {
                var products = _unitOfWork.GetRepository<Product>()
                    .GetList(predicate: p => p.Id == enquiryProduct.ProductId).Items;
                foreach (Product product in products)
                    listOfProduct.Add(product);
            }
            var result = listOfProduct.GroupBy(product => product.ProductName)
                .Select(productGroup =>
                new KeyValuePair<string, int>(productGroup.Key, productGroup.Count()));
            return result;
        }
        public IEnumerable<KeyValuePair<string, int>> GetMonthlyInquired(DateTime fromDate,
            DateTime toDate)
        {

            //var dictProducts = GetDictOfProducts();
            //IDictionary<int, IList<string>> dictEnquiries =
            //    new Dictionary<int, IList<string>>();
            //var enquiryWithProducts = _unitOfWork.GetReadOnlyRepository<Enquiry>()
            //     .GetList(predicate: enquiry => enquiry.EnquiryDate.Year == 2018,
            //    include: source =>
            //     source.Include(e => e.EnquiryProducts)).Items;
            //foreach (Enquiry enquiry in enquiryWithProducts)
            //{
            //    int month = enquiry.EnquiryDate.Month;
                
            //    foreach (EnquiryProduct enquiryProduct in enquiry.EnquiryProducts)
            //    {
            //        string productId = enquiryProduct.ProductId.ToString();
            //        string productName = dictProducts[productId].ProductName;
            //        if (dictEnquiries.ContainsKey(month))
            //            dictEnquiries[month].Add(productName);
            //        else
            //        {
            //            dictEnquiries.Add(month, new List<string>());
            //            dictEnquiries[month].Add(productName);
            //        }
            //    }
            //}
            //IList<KeyValuePair<string, IList<int>>> series = 
            //    new List<KeyValuePair<string, IList<int>>>();
            //IDictionary<string, IList<int>> dictSeries =
            //    new Dictionary<string, IList<int>>();
            //foreach (int key in dictEnquiries.Keys)
            //{
            //    var temp = dictEnquiries[key].GroupBy(keySelector => keySelector)
            //        .Select(
            //        selector => {
            //        if (dictSeries.ContainsKey(selector.Key){
            //            dictSeries[selector.Key].Add(selector.Count())
            //    }
            //}
               
            //}
            return null;
        }
        private IDictionary<string, Product> GetDictOfProducts()
        {
            var productKeyValuePair = _unitOfWork.GetReadOnlyRepository<Product>()
                    .GetList().Items
                    .Select(product =>
                    new KeyValuePair<string, Product>(product.Id.ToString(), product)
                    );
            IDictionary<string, Product> dictProducts =
                new Dictionary<string, Product>(productKeyValuePair.Count());
            foreach (KeyValuePair<string, Product> productKeyValue in productKeyValuePair)
            {
                dictProducts.Add(productKeyValue);
            }
            return dictProducts;
        }

    }

}
