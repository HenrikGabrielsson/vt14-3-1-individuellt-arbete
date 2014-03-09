using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Filmuthyrning.App_Start
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("RentalList", "", "~/Pages/RentalPages/RentalList.aspx");
            routes.MapPageRoute("MovieList", "Film/Alla", "~/Pages/MoviePages/MovieList.aspx");
        }
    }
}