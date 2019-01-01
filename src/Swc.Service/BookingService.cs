using System;
using System.Threading.Tasks;
using Api.Database.Entity.Accounts;
using Threenine.Data;
using Microsoft.Extensions.DependencyInjection;
using Api.Database.Entity.Enquiries;
using Api.Database.Entity;
using Api.Domain.Paging;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace Swc.Service
{
    public class BookingService : IBookingService
    {
        private readonly IUnitOfWork _unitOfWork;

        private RequestInfo _requestInfo;

        public BookingService(IUnitOfWork unitOfWork, IServiceProvider provider)
        {
            _unitOfWork = unitOfWork;

            _requestInfo = provider.GetService<RequestInfo>();
        }
        public async Task Insert(Enquiry model)
        {
            if (_unitOfWork.GetRepository<Voucher>().GetList(predicate: x => x.Id == model.Voucher.Id).Count == 0)
            {
                model.Voucher.VoucherTypeId = _unitOfWork.GetRepository<VoucherTypeMaster>().GetList().Items.FirstOrDefault().Id;
                _unitOfWork.GetRepository<Voucher>().Add(model.Voucher);
            }
            foreach(VoucherInfo vi in model.Voucher.VoucherInfos)
            {
                if (_unitOfWork.GetRepository<VoucherInfo>().GetList(predicate: x => x.Id == vi.Id).Count == 0)
                {
                    
                    _unitOfWork.GetRepository<VoucherInfo>().Add(vi);
                }
            }
            double CreditAmount = 0, DebitAmount = 0;
            foreach(VoucherInfo voucherInfo in model.Voucher.VoucherInfos)
            {
                if (voucherInfo.IsCredit)
                {
                    CreditAmount = CreditAmount + voucherInfo.Amount;
                    voucherInfo.bookId = _unitOfWork.GetRepository<AccountBook>().GetList(predicate:x=>x.ProgrammerId==AccountBookEnum.Booking.ToString()).Items.FirstOrDefault().Id;
                }
                else
                { 
                    DebitAmount = DebitAmount + voucherInfo.Amount;
                    voucherInfo.bookId = _unitOfWork.GetRepository<AccountBook>().GetList(predicate: x => x.ProgrammerId == AccountBookEnum.Cash.ToString()).Items.FirstOrDefault().Id;
                }
            }
            if (CreditAmount != DebitAmount)
            {
                foreach (VoucherInfo voucherInfo in model.Voucher.VoucherInfos)
                {
                    if (!voucherInfo.IsCredit)
                        voucherInfo.Amount = CreditAmount;
                }
            }
            _unitOfWork.GetRepository<Enquiry>().Update(model);
            _unitOfWork.SaveChanges();
            //Voucher voucher = new Voucher();
            //voucher.VoucherDate = model.Voucher.VoucherDate;
            //_r.InitilizeBaseEntityInfo(voucher);
            //VoucherInfo Credit = new VoucherInfo();
            //Credit.Voucher = voucher;
            //Credit.Amount = model.CashAmount.Amount;
            //Credit.IsCredit = true;
            //_unitOfWork.GetRepository<VoucherInfo>().Add(Credit);

            //VoucherInfo Debit = new VoucherInfo();
            //Credit.Voucher = voucher;
            //Debit.Amount = Credit.Amount;
            //Debit.IsCredit = false;
            //_unitOfWork.GetRepository<VoucherInfo>().Add(Debit);
            //_unitOfWork.GetRepository<Voucher>().Add(voucher);
            // _unitOfWork.SaveChanges();

        }
        public Threenine.Data.Paging.IPaginate<Enquiry> GetAllBooked(PagingParams pagingParams)
        {

            var enquiries = _unitOfWork.GetRepository<Enquiry>().GetList(
                orderBy: x => x.OrderBy(m => m.Created),
                predicate: x => x.BranchMasterId.ToString() == _requestInfo.BranchId && x.VoucherId!=null,
                include: x => x.
                Include(Contact => Contact.Contact).
                Include(Status => Status.Status).
                Include(m => m.EnquiryType).
                Include(n => n.EnquiryProducts).ThenInclude(c => c.Product).
                Include(n => n.EnquiryProducts).ThenInclude(a => a.EnquiryFinanceQuotations).
                Include(n => n.EnquiryExchangeQuotations).Include(n=>n.Voucher).ThenInclude(a=>a.VoucherInfos),
                index: pagingParams.PageNumber, size: pagingParams.PageSize);




            return enquiries;

        }
        public Enquiry GetBooked(string identifier)
        {

            var enq = _unitOfWork.GetRepository<Enquiry>().Single(
              orderBy: x => x.OrderBy(m => m.Created),
              predicate: x => x.BranchMasterId.ToString() == _requestInfo.BranchId && x.Identifier.ToLower() == identifier.ToLower(),
              include: x => x.
              Include(Contact => Contact.Contact).
              Include(Status => Status.Status).
              Include(m => m.EnquiryType).
              Include(n => n.EnquiryProducts).ThenInclude(c => c.Product).
              Include(n => n.EnquiryProducts).ThenInclude(a => a.EnquiryFinanceQuotations).
              Include(n => n.EnquiryExchangeQuotations));

            return enq;

        }
    }
}
