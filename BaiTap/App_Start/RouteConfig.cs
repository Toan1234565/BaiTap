using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BaiTap
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
<<<<<<< HEAD
                name: "API Default",
                url: "api/{controller}/{id}",
                defaults: new {
                    action = "Index", id = UrlParameter.Optional 
             });
            routes.MapRoute(
=======
>>>>>>> cf20b19c201406323190693f59e183afae7e4007
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
