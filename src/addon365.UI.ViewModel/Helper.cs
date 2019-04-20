using addon365.Database.Entity.Crm;
using addon365.Database.Entity.Enquiries;
using addon365.Domain.Entity.Enquiries;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;

namespace addon365.UI.ViewModel
{
    class Helper
    {
        public static void PrintEnquiry(ICrystalReport ReportObj,string Identifier)
        {
            if (ReportObj == null)
                return;
          
            MultiEnquiryModel invm = new addon365.WebClient.Service.WebService.EnquiriesService().GetMultiEnquiries(Identifier);
            ReportDocument rd = new ReportDocument();
            string assemblyFile = (
    new System.Uri(Assembly.GetExecutingAssembly().CodeBase)
).AbsolutePath;
            string path = Path.GetDirectoryName(assemblyFile);
            string g = path + @"\..\..\reports\reports\Enquiry.rpt";
            MessageBox.Show(g);
            rd.Load("reports\\Enquiry.rpt");
         
            DataSet ds = new DataSet();
            DataTable dt = ConvertToDataTable<Contact>(invm.contacts);
            dt.TableName = "Contact";
            ds.Tables.Add(dt);
            DataTable dtEnquiries = ConvertToDataTable<Enquiry>(invm.enquiries);
            dtEnquiries.TableName = "Enquiry";
            ds.Tables.Add(dtEnquiries);
            if (invm.EnquiryItems != null)
            {
                DataTable dtProducts = ConvertToDataTable<DomainEnquiryProduct>(invm.EnquiryItems);
                dtProducts.TableName = "EnquiryProducts";
                ds.Tables.Add(dtProducts);
            }
            if (invm.enquiryFinanceQuotations != null)
            {
                DataTable dtFinance = ConvertToDataTable<EnquiryFinanceQuotation>(invm.enquiryFinanceQuotations);
                dtFinance.TableName = "EnquiryFinanceQuotations";
                ds.Tables.Add(dtFinance);
            }
            DataTable dtExchange = ConvertToDataTable<EnquiryExchangeQuotation>(invm.enquiryExchangeQuotations);
            dtExchange.TableName = "EnquiryExchangeQuotations";
            ds.Tables.Add(dtExchange);
            DataTable dtAccessories = ConvertToDataTable<EnquiryAccessories>(invm.enquiryAccessories);
            dtAccessories.TableName = "EnquiryAccessories";
            ds.Tables.Add(dtAccessories);
            //= new DataTable();
            //dt.TableName = "Contact";
            //dt.Columns.Add("Name");
            //dt.Columns.Add("MobileNumber");

            //foreach (Enquiries cr in Enquiries)
            //{
            //    DataRow dr = dt.NewRow();
            //    dr["Name"] = cr.Contact.Name;
            //    dr["MobileNumber"] = cr.Contact.MobileNumber;
            //    dt.Rows.Add(dr);
            //}
            rd.SetDataSource(ds);
            foreach(ReportDocument sub in rd.Subreports)
            {
                sub.SetDataSource(ds);
            }

            ReportObj.ShowReport(rd);
        }
        private static DataTable ConvertToDataTable<TSource>(IEnumerable<TSource> source)
        {
            var props = typeof(TSource).GetProperties();

            var dt = new DataTable();

            foreach (PropertyInfo p in props)
            {
                Type proptype = p.PropertyType;
                if (p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                {
                    proptype = Nullable.GetUnderlyingType(proptype);
                }

                dt.Columns.Add(
                  new DataColumn(p.Name, proptype));

            }
            source.ToList().ForEach(
              i => dt.Rows.Add(props.Select(p => p.GetValue(i, null)).ToArray())
            );

            return dt;
        }
    }
}
