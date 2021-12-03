using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LR5b
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();// применяем атруъибуты маршрутизации


            routes.MapRoute(
                name: "AResearch",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "AResearch", action = "AA", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "CHResearch",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "CHResearch", action = "AD", id = UrlParameter.Optional }
           );
        }
    }
}
