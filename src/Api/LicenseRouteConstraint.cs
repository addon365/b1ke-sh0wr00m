using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Swc.Service;
using System;

namespace swcApi
{
    public class LicenseRouteConstraint : IRouteConstraint
    {

        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (!values.ContainsKey(routeKey))
                return false;

            object value = values[routeKey];
            var userService = (ILicenseService)httpContext.RequestServices
                .GetService(typeof(ILicenseService));
            return userService.IsExists(Convert.ToString(value));
        }
    }

}
