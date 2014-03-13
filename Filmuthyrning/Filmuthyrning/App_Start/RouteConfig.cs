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
            //Uthyrningar
            routes.MapPageRoute("RentalList", "", "~/Pages/RentalPages/RentalList.aspx");
            routes.MapPageRoute("RentalList2", "Uthyrning/Lista", "~/Pages/RentalPages/RentalList.aspx");
            routes.MapPageRoute("RentalSave", "Uthyrning/Spara", "~/Pages/RentalPages/RentalSave.aspx");

            //Kunder
            routes.MapPageRoute("CustomerSave", "Kund/Spara", "~/Pages/CustomerPages/CustomerSave.aspx");
            routes.MapPageRoute("CustomerList", "Kund/Lista", "~/Pages/CustomerPages/CustomerList.aspx");

            //Filmer
            routes.MapPageRoute("MovieList", "Film/Lista", "~/Pages/MoviePages/MovieList.aspx");

            //Error
            routes.MapPageRoute("ErrorPage", "Fel", "~/Pages/Shared/Error.aspx");

        }
    }
}