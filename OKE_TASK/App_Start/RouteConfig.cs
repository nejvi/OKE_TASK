using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Oke_task
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "SpecificCountry",
				url: "SpecificCountry/{id}",
				defaults: new { controller = "Home", action = "SpecificCountry", id = UrlParameter.Optional }
			);

			routes.MapRoute(
				name: "ListOfCountries",
				url: "CountryList",
				defaults: new { controller = "Home", action = "ListOfCountries"}
			);

			routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


		}
    }
}
