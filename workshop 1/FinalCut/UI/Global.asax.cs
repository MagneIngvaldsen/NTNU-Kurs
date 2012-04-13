using System.Web.Mvc;
using System.Web.Routing;

namespace ITVerket.FinalCut.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               "Search", // Route name
               "Search/{action}/{searchText}", // URL with parameters
               new { controller = "Search", action = "Index", searchText = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRoute(
                "MovieDetails", // Route name
                "Movie/{action}/{slug}", // URL with parameters
                new { controller = "Movie", action = "Index", slug = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRoute(
               "Default", // Route name
               "{controller}/{action}/{id}", // URL with parameters
               new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
           );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}