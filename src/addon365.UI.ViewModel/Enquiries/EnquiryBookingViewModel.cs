
using addon365.Database.Entity.Accounts;
using addon365.Database.Entity.Enquiries;
using Microsoft.Extensions.DependencyInjection;
using addon365.Database.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using addon365.IService;

namespace addon365.UI.ViewModel.Enquiries
{
    public class EnquiryBookingViewModel : ViewModelBase
    {
    

        private readonly IBookingService _repository;
        private VoucherInfo _currentAmount;
        private Enquiry _CurrentEnquiry;
        private ScreenOpenMode Mode=ScreenOpenMode.New;

        public EnquiryBookingViewModel(Enquiry enq)
        {

            CurrentEnquiry = enq;
           
            WireCommands();

            _repository = Startup.Instance.provider.GetService<IBookingService>();
            //_repository = new addon365.WebClient.Service.WebService.BookingService();
            if(enq.Voucher==null)
            { 
                CurrentAmount = new VoucherInfo();
            }
            else

            {
                Mode = ScreenOpenMode.Edit;
                CurrentAmount = enq.Voucher.VoucherInfos.Where(x => x.FieldInfo == FieldInfo.CashAmount.ToString()).Single();
            }



        }
        private void WireCommands()
        {
            SaveCommand = new RelayCommand(SaveBooking);
        }
        public RelayCommand SaveCommand
        {
            get;
            private set;
        }

        public VoucherInfo CurrentAmount
        {
            get
            {
                return _currentAmount;
            }
            set
            {
                if (_currentAmount != value)
                {

                    _currentAmount = value;
                    _currentAmount.FieldInfo = FieldInfo.CashAmount.ToString();
                    _currentAmount.IsCredit = true;
                    OnPropertyChanged("CurrentAmount");
                    SaveCommand.IsEnabled = true;
                }
            }
        }
        public Enquiry CurrentEnquiry
        {
            get
            {
                return _CurrentEnquiry;
            }
            set
            {
                if (_CurrentEnquiry != value)
                {

                    _CurrentEnquiry = value;
                  
                    OnPropertyChanged("CurrentEnquiry");
                    
                }
            }
        }


        public IMsgBox msg { get; set; }

        public async void SaveBooking()
        {
            try
            {
                if (Mode == ScreenOpenMode.New)
                    InsertBooking();
                else
                    EditBooking();

                SaveCommand.IsEnabled = false;
                if (msg != null)
                    msg.ShowUI("Saved Successfully");
            }
            catch(Exception ex)
            {
                if (msg != null)
                    msg.ShowUI(ex.Message);
            }
        }
        public async void EditBooking()
        {
            await _repository.Insert(CurrentEnquiry);
        }
        public async void InsertBooking()
        {

            Voucher voucher = new Voucher();
            voucher.VoucherDate = System.DateTime.Now;
            ICollection<VoucherInfo> lstVoucherInfo = new List<VoucherInfo>();
            CurrentAmount.VoucherId = voucher.Id;
            lstVoucherInfo.Add(CurrentAmount);

            VoucherInfo voucherInfoCash = new VoucherInfo();
            voucherInfoCash.VoucherId = voucher.Id;
            voucherInfoCash.Amount = CurrentAmount.Amount;
            voucherInfoCash.IsCredit = false;

            lstVoucherInfo.Add(voucherInfoCash);
            //InsertBooking ib = new InsertBooking();
            //ib.CashAmount = CurrentAmount;
            //ib.EnquiryId = CurrentEnquiry.Id;
            //Voucher v = new Voucher();
            //v.VoucherDate = System.DateTime.Now;
            //ib.Voucher = v;

            CurrentEnquiry.Voucher = voucher;
            CurrentEnquiry.VoucherId = voucher.Id;
            CurrentEnquiry.Voucher.VoucherInfos = lstVoucherInfo;
            await _repository.Insert(CurrentEnquiry);
        }
        public Result OnResult
        {
            get;
            set;
        }
    }
    enum FieldInfo { CashAmount}
}
