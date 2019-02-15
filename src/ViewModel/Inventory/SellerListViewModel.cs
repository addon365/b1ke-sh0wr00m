using Api.Database.Entity.Crm;
using Api.Database.Entity.Enquiries;
using Api.Database.Entity.Inventory;
using Api.Domain.Paging;
using CrystalDecisions.CrystalReports.Engine;
using Swc.Service;
using Swc.Service.Inventory;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace ViewModel.Inventory
{

    
    public class SellerListViewModel : ViewModelBase
    {
        private readonly ISellerService _repository;
        private Seller _Selected;
   
        public SellerListViewModel()
        {
            _repository = new addon.BikeShowRoomService.WebService.Inventory.SellerWebService();
            PagingViewModel = new PagingViewModel<Seller>(new Func<Api.Domain.Paging.PagingParams, Threenine.Data.Paging.IPaginate<Seller>>(RefreshData));
            WireCommands();
           
        }
       
        #region Commands
        private void WireCommands()
        {
            PrintCommand = new RelayCommand(PrintEnquiry);
           
            EditCommand = new RelayCommand(EditMethod);
        }
        public RelayCommand PrintCommand
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

        private Threenine.Data.Paging.IPaginate<Seller> RefreshData(PagingParams pagingParams)
        {

            return _repository.GetAll(pagingParams);

        }
        public PagingViewModel<Seller> PagingViewModel { get; private set; }
     
        public Seller Selected
        { get
            {
                return _Selected;
            }
            set
            {
                if(_Selected!=value)
                {
                    _Selected = value;
                    OnPropertyChanged("Selected");
                    PrintCommand.IsEnabled = true;
                    EditCommand.IsEnabled = true;
                }

            }
        }
        public Edit<string> Edit { get; set; }
        public ICrystalReport ReportObj { get; set; }

        public void PrintEnquiry()
        {
            try { 
            if (ReportObj == null)
                return;


            Helper.PrintEnquiry(ReportObj, Selected.SellerId);
            }
            catch(Exception ex)
            {
                MessageBox.ShowUI(ex.StackTrace);
            }
        }
     
        public void EditMethod()
        {
            if (Edit == null)
                return;

            Edit(Selected.SellerId);
        }

       
    }
}
