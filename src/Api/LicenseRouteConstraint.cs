using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Swc.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace swcApi
{
    public class LicenseRouteConstraint : IRouteConstraint
    {
        
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            // check nulls
            object value;
            if (values.TryGetValue(routeKey, out value) && value != null)
            {

               
                var userService = (ILicenseService)httpContext.RequestServices.GetService(typeof(ILicenseService));
                return userService.IsExists(Convert.ToString(value));
            }

            return false;
        }
    }

}
