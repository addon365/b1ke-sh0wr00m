using Api.Database.Entity.Crm;
using Api.Database.Entity.Enquiries;
using Api.Domain.Paging;
using CrystalDecisions.CrystalReports.Engine;
using Swc.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace ViewModel
{

    public delegate void OpenBooking(Enquiry enquiries);
    public class EnquiriesListViewModel : ViewModelBase
    {
        private readonly IEnquiriesService _repository;
        private Threenine.Data.Paging.IPaginate<Enquiry> _enquiries;
        private Enquiry _SelectedEnquiries;
        private PagingParams pagingParams;
        public EnquiriesListViewModel()
        {
            _repository = new addon.BikeShowRoomService.WebService.EnquiriesService();
            pagingParams = new PagingParams();
            pagingParams.PageNumber = 0;
            pagingParams.PageSize = 10;
            _enquiries = _repository.GetAllActive(pagingParams);
            WireCommands();
            PrintCommand.IsEnabled = true;
        }
        #region Commands
        private void WireCommands()
        {
            PrintCommand = new RelayCommand(PrintEnquiry);
            OpenBookingCommand = new RelayCommand(OpenBookingMethod);
        }
        public RelayCommand PrintCommand
        {
            get;
            private set;
        }
        public RelayCommand OpenBookingCommand
        {
            get;
            private set;
        }

        #endregion

        public Threenine.Data.Paging.IPaginate<Enquiry> Enquiries
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
        public Enquiry SelectedEnquiries
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
                    OpenBookingCommand.IsEnabled = true;
                }

            }
        }
        public OpenBooking OpenBooking { get; set; }
        public ICrystalReport ReportObj { get; set; }

        public void PrintEnquiry()
        {
            try { 
            if (ReportObj == null)
                return;


            Helper.PrintEnquiry(ReportObj, SelectedEnquiries.Identifier);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        public void OpenBookingMethod()
        {
            if (OpenBooking == null)
                return;

            OpenBooking(SelectedEnquiries);
        }
     
        //public string GetFriendlyTypeName(Type type)
        //{
        //    if (type.IsGenericParameter)
        //    {
        //        return type.Name;
        //    }

        //    if (!type.IsGenericType)
        //    {
        //        return type.FullName;
        //    }

        //    var builder = new System.Text.StringBuilder();
        //    var name = type.Name;
        //    var index = name.IndexOf("`");
        //    builder.AppendFormat("{0}.{1}", type.Namespace, name.Substring(0, index));
        //    builder.Append('<');
        //    var first = true;
        //    foreach (var arg in type.GetGenericArguments())
        //    {
        //        if (!first)
        //        {
        //            builder.Append(',');
        //        }
        //        builder.Append(GetFriendlyTypeName(arg));
        //        first = false;
        //    }
        //    builder.Append('>');
        //    return builder.ToString();
        //}
    }
}
