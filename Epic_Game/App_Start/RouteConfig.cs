using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Epic_Game
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Pay",
                url: "Pay/ToECpay",
                defaults: new { controller = "Pay", action = "ToECpay" }
            );

            routes.MapRoute(
                name: "Search",
                url: "Home/Search/{id}",
                defaults: new { controller = "Home", action = "Search" , SearchProduct = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Comment",
                url: "Product/CreateComment",
                defaults: new { controller = "Product", action = "CreateComment" }
            );

            routes.MapRoute(
                name: "FindProductID",
                url: "Product/{ProductId}",
                defaults: new { controller = "Product", action = "Index", ProductId = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "PayProductID",
                url: "Pay/{ProductId}",
                defaults: new { controller = "Pay", action = "Index", ProductId = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
