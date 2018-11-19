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


            Helper.PrintEnquiry(ReportObj, SelectedEnquiries.Identifier);
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
