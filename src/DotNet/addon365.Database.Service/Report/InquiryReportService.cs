using addon365.Database.Entity.Report;
using System;
using System.Collections.Generic;
using Threenine.Data;

namespace addon365.Database.Service.Report
{
    /// <summary>
    /// Implementation to serve Inquiry reports in different formats.
    /// </summary>
    public class InquiryReportService : IInquiryReportService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InquiryReportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<InquiryReport> GetReport(ReportType type)
        {
            switch (type)
            {
                case ReportType.NAME:
                    return _unitOfWork.GetRepository<InquiryReport>()
                            .Query(ReportQueries.COUNT_BY_NAME);
                case ReportType.YEAR:
                    return _unitOfWork.GetRepository<InquiryReport>()
                            .Query(ReportQueries.COUNT_BY_YEAR);
                case ReportType.MONTH:
                    throw new NotImplementedException("Need to implement");
            }

            throw new ArgumentException("Given Type not available.");

        }
    }

}
