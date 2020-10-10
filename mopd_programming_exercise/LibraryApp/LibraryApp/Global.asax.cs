using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using LibraryApp.Models;
using LibraryApp.Logic;

namespace LibraryApp
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // add routes
            RegisterCustomRoutes(RouteTable.Routes);

            // custom roles and users
            RoleActions roleActions = new RoleActions();
            RoleActions.AdduserAndRole();
        }

        void RegisterCustomRoutes(RouteCollection routes)
        {
            routes.MapPageRoute(
                "BooksByGenreRoute",
                "genre/{genre_name}",
                "~/Browse.aspx"
            );
            routes.MapPageRoute(
                "BookByNameRoute",
                "book/{book_name}",
                "~/BookDetail.aspx"
            );
        }
    }
}