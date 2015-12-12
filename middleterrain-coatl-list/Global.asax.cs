using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using middleterraincoatllist.Controllers;

namespace middleterraincoatllist
{
    public class MvcApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// http://stackoverflow.com/questions/717628/asp-net-mvc-404-error-handling
        /// </summary>
        protected void Application_EndRequest()
        {
            if (Context.Response.StatusCode == 404)
            {
                Response.Clear();

                var rd = new RouteData();
                rd.DataTokens["area"] = "AreaName"; // In case controller is in another area
                rd.Values["controller"] = "Errors";
                rd.Values["action"] = "NotFound";

                IController c = new ErrorsController();
                c.Execute(new RequestContext(new HttpContextWrapper(Context), rd));
            }
        }

        public static void RegisterRoutes (RouteCollection routes)
        {
            routes.IgnoreRoute ("{resource}.axd/{*pathInfo}");

            routes.MapRoute (
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = "" }
            );

        }

        public static void RegisterGlobalFilters (GlobalFilterCollection filters)
        {
            filters.Add (new HandleErrorAttribute());
        }

        protected void Application_Start ()
        {
            AreaRegistration.RegisterAllAreas ();
            RegisterGlobalFilters (GlobalFilters.Filters);
            RegisterRoutes (RouteTable.Routes);
			SnakesController.F1 ();
        }
/*
		protected void Session_Start(Object sender, EventArgs e) 
		{
			// don't remove this "empty" function, actually it's exisetence creates a session object
			Session["_my_variable"] = "content";
		}
*/	
    }
}
