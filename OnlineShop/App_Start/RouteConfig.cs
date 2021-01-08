using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineShop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "ProductCategory",
               url: "san-pham/{metaTitle}-{id}",
               defaults: new { controller = "Product", action = "Category", id = UrlParameter.Optional },
               namespaces: new[] { "OnlineShop.Controllers" }
           );

            routes.MapRoute(
               name: "ProductDetail",
               url: "chi-tiet/{ProductName}-{id}",
               defaults: new { controller = "Product", action = "ProductDetail", id = UrlParameter.Optional },
               namespaces: new[] { "OnlineShop.Controllers" }
           );

            routes.MapRoute(
               name: "ThemGioHang",
               url: "them-gio-hang",
               defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
               namespaces: new[] { "OnlineShop.Controllers" }
           );

            routes.MapRoute(
              name: "Gioithieu",
              url: "gioi-thieu",
              defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional },
              namespaces: new[] { "OnlineShop.Controllers" }
          );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShop.Controllers" }
            );
        }
    }
}