using Microsoft.Extensions.DependencyInjection;
using addon365.Database.Service;
using System;
using System.Collections.Generic;
using System.Text;


namespace addon365.UI.ViewModel
{
    public class Startup
    {
        public IServiceProvider provider;
        private static Startup _objSelf;
        public Startup()
        {

           ServiceCollection services = new ServiceCollection();
            provider = services.AddSingleton<IBookingService,addon365.WebClient.Service.WebService.BookingService>()
                                              .AddTransient<IEnquiriesService, addon365.WebClient.Service.WebService.EnquiriesService>()
                                              .BuildServiceProvider();
            
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
