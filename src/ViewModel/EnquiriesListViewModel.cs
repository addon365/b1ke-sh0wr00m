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
    public delegate void Edit<T>(T ViewModel);
    public class EnquiriesListViewModel : ViewModelBase
    {
        private readonly IEnquiriesService _repository;
        private Threenine.Data.Paging.IPaginate<Enquiry> _enquiries;
        private Enquiry _SelectedEnquiries;
        private PagingParams pagingParams;
        public EnquiriesListViewModel()
        {
            _repository = new addon.BikeShowRoomService.WebService.EnquiriesService();
            PagingViewModel = new PagingViewModel<Enquiry>(new Func<Api.Domain.Paging.PagingParams, Threenine.Data.Paging.IPaginate<Enquiry>>(RefreshData));
            WireCommands();
           
        }
        #region Commands
        private void WireCommands()
        {
            PrintCommand = new RelayCommand(PrintEnquiry);
            OpenBookingCommand = new RelayCommand(OpenBookingMethod);
            EditCommand = new RelayCommand(EditMethod);
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
        public RelayCommand EditCommand
        {
            get;
            private set;
        }
        #endregion

        private Threenine.Data.Paging.IPaginate<Enquiry> RefreshData(PagingParams pagingParams)
        {

            return _repository.GetAllActive(pagingParams);

        }
        public PagingViewModel<Enquiry> PagingViewModel { get; private set; }
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
                    PrintCommand.IsEnabled = true;
                    OpenBookingCommand.IsEnabled = true;
                    EditCommand.IsEnabled = true;
                }

            }
        }
        public OpenBooking OpenBooking { get; set; }
        public Edit<string> Edit { get; set; }
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
                MessageBox.ShowUI(ex.StackTrace);
            }
        }
        public void OpenBookingMethod()
        {
            if (OpenBooking == null)
                return;

            OpenBooking(SelectedEnquiries);
        }
        public void EditMethod()
        {
            if (Edit == null)
                return;

            Edit(SelectedEnquiries.Identifier);
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
