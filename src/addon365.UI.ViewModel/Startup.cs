using addon365.Database;
using addon365.Database.Service;
using addon365.IService;
using addon365.IService.Accounts;
using addon365.IService.Chit;
using addon365.IService.Crm;
using addon365.IService.Inventory;
using addon365.IService.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using Threenine.Data.DependencyInjection;

namespace addon365.UI.ViewModel
{
    public class Startup
    {
        public IServiceProvider provider;
        private static Startup _objSelf;
        ServiceCollection services;
        public Startup()
        {
            services = new ServiceCollection();
#if Desktop


            provider=services
                .AddDbContext<ApiContext>(options => options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=config69;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"), ServiceLifetime.Transient)
                .AddUnitOfWork<ApiContext>()
                .AddTransient<IUserService,addon365.Database.Service.UserService>()
                .AddTransient<IVoucherTypeService, addon365.Database.Service.Accounts.VoucherTypeService>()
                .AddTransient<IAccountBookService, addon365.Database.Service.Accounts.AccountBookService>()
                .AddTransient<ISubscribeService, addon365.Database.Service.Chit.SubscribeService>()
                .AddTransient<IChitDueService, addon365.Database.Service.Chit.ChitDueService>()
                .AddTransient<ISchemeService,addon365.Database.Service.Chit.SchemeService>()
                .AddTransient<IFollowUpService,addon365.Database.Service.Crm.FollowUpService>()
                .AddTransient<IContactService, addon365.Database.Service.Crm.ContactService>()
                .AddTransient<IEnquiriesService,addon365.Database.Service.EnquiryService>()
                .AddTransient<IBookingService, addon365.Database.Service.BookingService>()
                .AddTransient<IPurchaseService, addon365.Database.Service.Inventory.PurchaseService>()
                .AddTransient<ISellerService, addon365.Database.Service.Inventory.SellerService>()
                .AddTransient<ISalesService, addon365.Database.Service.Sales.SalesService>()
                .AddTransient<IProductService,addon365.Database.Service.ProductService>()
                .AddSingleton<RequestInfo,addon365.Database.Service.RequestInfo>()
                .BuildServiceProvider();



#else
           
            provider=services
                .AddDbContext<ApiContext>(options => options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=config69;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
                .AddUnitOfWork<ApiContext>()
                .AddTransient<IVoucherTypeService, addon365.Database.Service.Accounts.VoucherTypeService>()
                .AddTransient<IAccountBookService, addon365.Database.Service.Accounts.AccountBookService>()
                .AddTransient<ISubscribeService, addon365.Database.Service.Chit.SubscribeService>()
                .AddTransient<IChitDueService, addon365.Database.Service.Chit.ChitDueService>()
                .AddTransient<ISchemeService,addon365.Database.Service.Chit.SchemeService>().BuildServiceProvider();

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
