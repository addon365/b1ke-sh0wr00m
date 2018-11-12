using Api.Database.Entity.Crm;
using Api.Database.Entity.Enquiries;
using Api.Domain.Enquiries;
using CrystalDecisions.CrystalReports.Engine;
using Swc.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ViewModel
{
    public class EnquiriesListViewModel : ViewModelBase
    {
        private readonly IEnquiriesService _repository;
        private IEnumerable<Enquiries> _enquiries;
        private Enquiries _SelectedEnquiries;
        public EnquiriesListViewModel()
        {
            _repository = new addon.BikeShowRoomService.WebService.EnquiriesService();

            _enquiries = _repository.GetAllActive();
            WireCommands();
            PrintCommand.IsEnabled = true;
        }
        #region Commands
        private void WireCommands()
        {
            PrintCommand = new RelayCommand(PrintEnquiry);
        }
        public RelayCommand PrintCommand
        {
            get;
            private set;
        }
        
        #endregion

        public IEnumerable<Enquiries> Enquiries
        {
            get
            {
        
                return _enquiries;
            }

            set
            {
                if (_enquiries != value)
                {
                    _enquiries = value;
                    OnPropertyChanged("Enquiries");

                }
            }
        }
        public Enquiries SelectedEnquiries
        { get
            {
                return _SelectedEnquiries;
            }
            set
            {
                if(_SelectedEnquiries!=value)
                {
                    _SelectedEnquiries = value;
                    OnPropertyChanged("SelectedEnquiries");
                }

            }
        }
        public ICrystalReport ReportObj { get; set; }

        public void PrintEnquiry()
        {
            if (ReportObj == null)
                return;

            MultiEnquiryModel invm = _repository.GetMultiEnquiries(SelectedEnquiries.Identifier);
            ReportDocument rd = new ReportDocument();
            string assemblyFile = (
    new System.Uri(Assembly.GetExecutingAssembly().CodeBase)
).AbsolutePath;
            string path = Path.GetDirectoryName(assemblyFile);
            rd.Load(path+@"\..\..\reports\reports\Enquiry.rpt");
            DataSet ds = new DataSet();
            DataTable dt = ConvertToDataTable<Contact>(invm.contacts);
            dt.TableName = "Contact";
            ds.Tables.Add(dt);
            DataTable dtEnquiries = ConvertToDataTable<Enquiry>(invm.enquiries);
            dtEnquiries.TableName = "Enquiry";
            ds.Tables.Add(dtEnquiries);
            if(invm.EnquiryProducts!=null)
            { 
            DataTable dtProducts= ConvertToDataTable<DomainEnquiryProduct>(invm.EnquiryProducts);
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
               
            ReportObj.ShowReport(rd);
        }
        DataTable ConvertToDataTable<TSource>(IEnumerable<TSource> source)
        {
            var props = typeof(TSource).GetProperties();

            var dt = new DataTable();
           
            foreach(PropertyInfo p in props)
            {
                Type proptype = p.PropertyType;
                if (p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                {
                    proptype = Nullable.GetUnderlyingType(proptype);
                }
                    
                dt.Columns.Add(
                  new DataColumn(p.Name,proptype));
            
            }
            source.ToList().ForEach(
              i => dt.Rows.Add(props.Select(p => p.GetValue(i, null)).ToArray())
            );

            return dt;
        }
        public string GetFriendlyTypeName(Type type)
        {
            if (type.IsGenericParameter)
            {
                return type.Name;
            }

            if (!type.IsGenericType)
            {
                return type.FullName;
            }

            var builder = new System.Text.StringBuilder();
            var name = type.Name;
            var index = name.IndexOf("`");
            builder.AppendFormat("{0}.{1}", type.Namespace, name.Substring(0, index));
            builder.Append('<');
            var first = true;
            foreach (var arg in type.GetGenericArguments())
            {
                if (!first)
                {
                    builder.Append(',');
                }
                builder.Append(GetFriendlyTypeName(arg));
                first = false;
            }
            builder.Append('>');
            return builder.ToString();
        }
    }
}
