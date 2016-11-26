using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ParkingCheck
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private Timer mytimer;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //mytimer = new Timer(onTimer, null, 1000, 5000);
            
        }

        private void onTimer(object state)
        {
            Console.WriteLine("Entered timer");
        }
    }
}
