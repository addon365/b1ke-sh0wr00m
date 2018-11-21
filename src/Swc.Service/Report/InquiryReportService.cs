using Api.Database.Entity.Enquiries;
using Api.Database.Entity.Products;
using Api.Database.Entity.Report;
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
        public IEnumerable<InquiredMonthly> GetMonthlyInquired(DateTime fromDate,
            DateTime toDate)
        {
            var result = _unitOfWork.GetReadOnlyRepository<InquiredMonthly>()
                .Query(ReportQueries.PRODUCTS_BASED_MONTH, new object[] { }).ToList();
            return result;
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
