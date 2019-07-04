using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //Define from specific to generic route
            //Define a custom route
            routes.MapRoute(
                "MoviesByReleaseDate",//name of the route
                "movies/released/{year}/{month}",//url pattern
                new { controller ="Movies",action ="ByReleaseDate" },//specify the defaults
                //add constrain to url
                new { year =@"\d{4}",month =@"\d{2}"}); // @"\" = "\\" 
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
