using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DataNissen
{
    public class RouteConfig
    {

        private static string AllowedHostName = "";

        public static string AllowedHost()
        {
            return AllowedHostName;
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Member",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Member", action = "Index", id = UrlParameter.Optional }
            );

            AllowOnlyCallsFromHost("localhost");
        }

        public static void AllowOnlyCallsFromHost(string hostname)
        {
            AllowedHostName = hostname;
        }
    }
}