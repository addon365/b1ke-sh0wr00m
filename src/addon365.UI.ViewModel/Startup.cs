using Microsoft.Extensions.DependencyInjection;
using addon365.Database.Service;
using System;
using addon365.Database.Service.Chit;
using addon365.Database.Service.Accounts;
using addon365.Database;
using Microsoft.EntityFrameworkCore;
using Threenine.Data.DependencyInjection;
using addon365.UI.ViewModel.Inventory;
using addon365.Database.Service.Inventory;

namespace addon365.UI.ViewModel
{
    public class Startup
    {
        public IServiceProvider provider;
        private static Startup _objSelf;
        public Startup()
        {
            ServiceCollection services = new ServiceCollection();
#if Desktop


            services.AddDbContext<ApiContext>(options => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=config69;Trusted_Connection=True;MultipleActiveResultSets=true"))
               .AddUnitOfWork<ApiContext>();
            services.AddSingleton<IBookingService, BookingService>(); //1
            services.AddTransient<IEnquiriesService, EnquiryService>(); //2
            services.AddTransient<IChitDueService, ChitDueService>(); //
            services.AddTransient<IVoucherTypeService, VoucherTypeService>();
            services.AddTransient<IAccountBookService, AccountBookService>();

            provider = services.BuildServiceProvider();

#else
           
            provider = new ServiceCollection()
                     .AddTransient<PurchaseListViewModel>()
                     .AddTransient<IPurchaseService, addon365.WebClient.Service.WebService.Inventory.PurchaseWebService>()
                     .AddTransient<ISubscribeService, addon365.WebClient.Service.WebService.Chit.SubsriberService>()
                     .AddTransient<IChitDueService,addon365.WebClient.Service.WebService.Chit.ChitDueClientService>()
                     .AddSingleton<IBookingService, addon365.WebClient.Service.WebService.BookingService>() //1
                     .AddTransient<IEnquiriesService, addon365.WebClient.Service.WebService.EnquiriesService>() //2
                     .BuildServiceProvider();
#endif

        }
        public static Startup Instance
        {
            get
            {
                if (_objSelf == null)
                {
                    _objSelf = new Startup();
               
                }

                return _objSelf;
            }
        }
    }
}
