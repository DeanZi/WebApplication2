using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /*routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Default", action = "Index", id = UrlParameter.Optional }
            );*/

            routes.MapRoute(
                name: "FirstMission",
                url: "display/{ip}/{port}",
                defaults: new { controller = "Default", action = "Index" }
          );

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
              name: "SecondMission",
              url: "display/{ip}/{port}/{frequency}",
              defaults: new { controller = "Default", action = "StartDrawing" }
        );
        }

    }
}
