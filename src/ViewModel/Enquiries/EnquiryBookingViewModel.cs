
using Api.Database.Entity.Accounts;
using Api.Database.Entity.Enquiries;
using Api.Domain.Accounts;
using Api.Domain.Booking;
using Microsoft.Extensions.DependencyInjection;
using Swc.Service;
using Swc.Service.Crm;
using System;
using System.Collections.Generic;

namespace ViewModel.Enquiries
{
    public class EnquiryBookingViewModel : ViewModelBase
    {
    

        private readonly IBookingService _repository;
        private DomainVoucherInfo _currentAmount;
        private Enquiry _CurrentEnquiry;


        public EnquiryBookingViewModel(Enquiry enq)
        {

            CurrentEnquiry = enq;
           
            WireCommands();

            _repository = Startup.Instance.provider.GetService<IBookingService>();
            _repository = new addon.BikeShowRoomService.WebService.BookingService();
            CurrentAmount = new DomainVoucherInfo();


        }
        private void WireCommands()
        {
            InsertCommand = new RelayCommand(InsertBooking);
        }
        public RelayCommand InsertCommand
        {
            get;
            private set;
        }

        public DomainVoucherInfo CurrentAmount
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
                    _currentAmount.book = AccountBook.Booking;
                    _currentAmount.FieldInfo = FieldInfo.CashAmount.ToString();
                    _currentAmount.IsCredit = true;
                    OnPropertyChanged("CurrentAmount");
                    InsertCommand.IsEnabled = true;
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

        public async void InsertBooking()
        {
            try
            { 
            InsertBooking ib = new InsertBooking();
            ib.CashAmount = CurrentAmount;
            ib.EnquiryId = CurrentEnquiry.Id;
            Voucher v = new Voucher();
            v.VoucherDate = System.DateTime.Now;
            ib.Voucher = v;
            await _repository.Insert(ib);
            }
            catch(Exception ex)
            {
                if (msg != null)
                    msg.ShowUI(ex.Message);
            }
        }
        public Result OnResult
        {
            get;
            set;
        }
    }
    enum FieldInfo { CashAmount}
}
