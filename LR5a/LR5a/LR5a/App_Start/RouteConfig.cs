using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LR5a
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "CResearch",
               url: "CResearch/{action}",
               defaults: new { controller = "CResearch", action = "C01" }
           );

            routes.MapRoute(
                name: "V2",
                url: "V2/{controller}/{action}",
                defaults: new { controller = "MResearch", action = "M02" },
                constraints: new { action = @"M0[1|2]" }
            );

            routes.MapRoute(
                name: "V3",
                url: "V3/{controller}/{id}/{action}",
                defaults: new { controller = "MResearch", action = "M03", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "MResearch", action = "M01", id = UrlParameter.Optional },
                constraints: new { action = @"M0[1|2]" }
            );

            routes.MapRoute(
                name: "err",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "MResearch", action = "MXX", id = UrlParameter.Optional }
            );
        }
    }
}
