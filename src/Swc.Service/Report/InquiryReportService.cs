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
        public IEnumerable<KeyValuePair<string, int>> GetBasedOnProduct(DateTime fromDate, DateTime toDate)
        {
            var enquiries = _unitOfWork.GetReadOnlyRepository<Enquiry>().GetList().Items;
            //var enquiryProducts = _unitOfWork.GetReadOnlyRepository<Enquiry>()
            //     .GetList(include: source =>
            //     source.Include(e => e.EnquiryProducts));

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
                .Select(productGroup => new KeyValuePair<string, int>(productGroup.Key, productGroup.Count()));
            return result;
        }


    }
}
