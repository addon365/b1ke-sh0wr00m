using Microsoft.Extensions.DependencyInjection;
using Swc.Service;
using System;
using System.Collections.Generic;
using System.Text;


namespace ViewModel
{
    public class Startup
    {
        public IServiceProvider provider;
        private static Startup _objSelf;
        public Startup()
        {

           ServiceCollection services = new ServiceCollection();
            provider = services.AddSingleton<IBookingService,addon.BikeShowRoomService.WebService.BookingService>()
                                              .AddTransient<IEnquiriesService, addon.BikeShowRoomService.WebService.EnquiriesService>()
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
