using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using gym_mgmt_01.Helper_Code.Common;

namespace gym_mgmt_01
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
           
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        ///    WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //For API Authentication
        //    var basicAuthMessageHandler = new gym_mgmt_01.Helper_Code.Common.BasicAuthMessageHandler();
        //    basicAuthMessageHandler.PrincipalProvider = new gym_mgmt_01.Helper_Code.Common.adminPrincipalProvider();
            //start message handler
         //   GlobalConfiguration.Configuration.MessageHandlers.Add(basicAuthMessageHandler);
        }
        protected void Session_Start(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(" Session Start !!! " + DateTime.Now.ToShortTimeString());
        }
        protected void Session_End(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(" Session Goes End !!! " + DateTime.Now.ToShortTimeString());
        }
    }
}
