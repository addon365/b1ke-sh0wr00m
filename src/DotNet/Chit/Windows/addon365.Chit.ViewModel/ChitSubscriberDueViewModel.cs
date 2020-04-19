

using addon365.Chit.DomainEntity;
using addon365.Chit.DataService;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Diagnostics;
using System.Text.Json;
using System.IO;
using addon365.Chit.ViewModel.ReportModel;

namespace addon365.Chit.ViewModel
{
    public class ChitSubscriberDueViewModel : ViewModelBase
    {
        private IChitSubscriberDueDataService _chitSubscriberDueDataService;
        private ChitSubscriberModel _selectedChitSubscriber;
        string _title,_accessId,_searchSubscriberAccessId;
        DateTime _billDate;
        int? _totalDue;
        decimal _paymentAmount;
        private ObservableCollection<ChitSubscriberDueListModel> _dueDetail;
        public ChitSubscriberDueViewModel(IChitSubscriberDueDataService chitSubscriberDueDataService)
        {
            try { 
                this._chitSubscriberDueDataService = chitSubscriberDueDataService;
                if (IsInDesignMode)
                {
                    Title = "Hello MVVM Light (Design Mode)";
                }
                else
                {
                    Title = "Hello MVVM Light";
                    LoadMasterData();
                }

                SaveSubscriberDueCommand = new RelayCommand(SaveSubscriberDue);
                FindSubscriberByIdCommand = new RelayCommand(FindSubscriberById);
            }
            catch(Exception ex)
            {
                ex = addon365.Common.Helper.ExceptionHelper.GetRootException(ex);
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ex.Message));

            }
        }
        public RelayCommand SaveSubscriberDueCommand { get; private set; }
        public RelayCommand FindSubscriberByIdCommand { get; private set; }
        public string Title 
        {
            get 
            {
                return _title;
            }
            set 
            {
                _title = value;
                RaisePropertyChanged("Title");
            } 
        }
        public string AccessId
        {
            get
            {
                return _accessId;
            }
            set
            {
                _accessId = value;
                RaisePropertyChanged("AccessId");
            }
        }
        public DateTime BillDate
        {
            get
            {
                return _billDate;
            }
            set
            {
                _billDate = value;
                RaisePropertyChanged("BillDate");
            }
        }
        public string SearchSubscriberAccessId
        {
            get
            {
                return _searchSubscriberAccessId;
            }
            set
            {
                _searchSubscriberAccessId = value;
                RaisePropertyChanged("SearchSubscriberAccessId");
            }
        }
        public string FullName
        {
            get
            {
                string fullName = string.Empty;
                if (SelectedChitSubscriber != null)
                    fullName= SelectedChitSubscriber.Customer.FirstName + " " + SelectedChitSubscriber.Customer.LastName;

                return fullName;
            }
          
        }
   
        public int[] DueNumbers
        {
            get 
            {
                int[] dueNumbers = { 1 };
                return dueNumbers;

            }
        }
        public int? SelectedDueNumber
        {
            get
            {
                return _totalDue;
            }
            set
            {
                _totalDue = value;

                if(SelectedChitSubscriber!=null)
                    PaymentAmount=SelectedChitSubscriber.ChitGroup.ChitDueAmount*(int) _totalDue;
                
                RaisePropertyChanged("SelectedDueNumber");
            }
        }
        public Decimal PaymentAmount
        {
            get
            {
                return _paymentAmount;
            }
            set
            {
                _paymentAmount = value;
                RaisePropertyChanged("PaymentAmount");
            }
        }

        public ObservableCollection<ChitSubscriberDueListModel>  DueDetail
        {
            get
            {
                return _dueDetail;
            }
        }

        public ChitSubscriberModel SelectedChitSubscriber
        {
            get
            {
                return _selectedChitSubscriber;
            }
            set
            {
                _selectedChitSubscriber = value;
                RaisePropertyChanged("SelectedChitSubscriber");
                RaisePropertyChanged("FullName");
                RaisePropertyChanged("SelectedDueNumber");

            }
        }
        public void LoadMasterData()
        {
            var masterData = _chitSubscriberDueDataService.GetMasterData();
            

            
            //_chitSubscriberList = new ObservableCollection<ChitSubscriberModel>(masterData.ChitSubscriberList);
            //this.RaisePropertyChanged(() => this.ChitSubscriberList);

            Int64 id = 1;
            if (masterData.MaxAccessId != null && masterData.MaxAccessId != "")
                id = Convert.ToInt64(masterData.MaxAccessId) + 1;

            AccessId = id.ToString();
        }

        public void SaveSubscriberDue()
        {
            try
            {
                _chitSubscriberDueDataService.Insert(GetCurrentSubcriberDue());
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage("Subscriber Saved."));

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                };
                var jsonModel = SelectedChitSubscriber;
                var DueDetail = _chitSubscriberDueDataService.Get(AccessId);
                var DueDetailReportModel = new ChitDueBillMasterReportModel { KeyId = DueDetail.KeyId.ToString(), BillNo = DueDetail.AccessId, BillDate = DueDetail.TransactionDate, CustomerAccessId = DueDetail.ChitSubscriber.AccessId, CustomerName = DueDetail.ChitSubscriber.Customer.FirstName };
                var modelJson = JsonSerializer.Serialize(DueDetailReportModel, options);
                var composedJson = "{'master1':[" + modelJson + "]}";
                File.WriteAllText(@"d:\test.json", composedJson);
                string ReportName = "DueReceipt.rpt";
                using (var process = new Process())
                {
                    
                    process.StartInfo.FileName = @"D:\Development\Project\GitHub\addon365.CrystalReportViewer.Net4\addon365.CrystalReportViewer.Net4\bin\Debug\addon365.CrystalReportViewer.Net4.exe";
                    process.StartInfo.Arguments = $"{ReportName}";
                    //process.StartInfo.FileName = @"cmd.exe";
                    //process.StartInfo.Arguments = @"/c dir";      // print the current working directory information
                    //process.StartInfo.CreateNoWindow = true;
                    //process.StartInfo.UseShellExecute = false;
                    //process.StartInfo.RedirectStandardOutput = true;
                    //process.StartInfo.RedirectStandardError = true;

                    //process.OutputDataReceived += (sender, data) => Console.WriteLine(data.Data);
                    //process.ErrorDataReceived += (sender, data) => Console.WriteLine(data.Data);
                    //Console.WriteLine("starting");
                    process.Start();
                    //process.BeginOutputReadLine();
                    //process.BeginErrorReadLine();
                    //var exited = process.WaitForExit(1000 * 10);     // (optional) wait up to 10 seconds
                    //Console.WriteLine($"exit {exited}");
                }
                Clear();
            }
            catch (Exception ex)
            {

                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ex.Message));
            }
        }
        public void FindSubscriberById()
        {
            try
            {
                if (SearchSubscriberAccessId == String.Empty)
                {
                    throw new Exception("Please enter Id");
                }
                ChitDueSubscriberDetailModel chitDueSubscriberDetailModel = _chitSubscriberDueDataService.GetSubscriberDetail(SearchSubscriberAccessId);
                    //SelectedChitSubscriber = _chitSubscriberList.First(x => x.AccessId == SearchSubscriberAccessId);
                SelectedChitSubscriber = chitDueSubscriberDetailModel.Subscriber;

                _dueDetail = new ObservableCollection<ChitSubscriberDueListModel>(chitDueSubscriberDetailModel.DueDetail);
                this.RaisePropertyChanged(() => this.DueDetail);

            }

            catch (Exception ex)
            {
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ex.Message));
            }

        }
        
        private ChitSubscriberDueModel GetCurrentSubcriberDue()
        {
            Validate();
            var model = new ChitSubscriberDueModel {ChitSubscriberKeyId=SelectedChitSubscriber.KeyId, TransactionDate=BillDate,Amount = this.PaymentAmount,AccessId=this.AccessId};
            return model;
        }

        private void Validate()
        {
            
        }
        public void Clear()
        {
            SearchSubscriberAccessId = string.Empty;
            SelectedChitSubscriber = null;
            SelectedDueNumber =null;
            PaymentAmount = 0;
            LoadMasterData();

        }
       
        
    }
}
