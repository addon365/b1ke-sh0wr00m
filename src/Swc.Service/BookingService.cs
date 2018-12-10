using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Api.Database.Entity.Accounts;
using Api.Domain.Booking;
using Threenine.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Swc.Service
{
    public class BookingService : IBookingService
    {
        private readonly IUnitOfWork _unitOfWork;

        private RequestInfo _r;

        public BookingService(IUnitOfWork unitOfWork, IServiceProvider provider)
        {
            _unitOfWork = unitOfWork;

            _r = provider.GetService<RequestInfo>();
        }
        public async Task Insert(InsertBooking model)
        {
            Voucher voucher = new Voucher();
            voucher.VoucherDate = model.Voucher.VoucherDate;
            _r.InitilizeBaseEntityInfo(voucher);
            VoucherInfo Credit = new VoucherInfo();
            Credit.VoucherId = voucher.Id;
            Credit.Amount = model.CashAmount.Amount;
            Credit.IsCredit = true;
            _unitOfWork.GetRepository<VoucherInfo>().Add(Credit);

            VoucherInfo Debit = new VoucherInfo();
            Credit.VoucherId = voucher.Id;
            Debit.Amount = Credit.Amount;
            Debit.IsCredit = false;
            _unitOfWork.GetRepository<VoucherInfo>().Add(Debit);
            _unitOfWork.GetRepository<Voucher>().Add(voucher);
             _unitOfWork.SaveChanges();
       
        }
    }
}
