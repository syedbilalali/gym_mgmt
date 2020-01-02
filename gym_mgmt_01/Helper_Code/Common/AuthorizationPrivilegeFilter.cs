using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
namespace gym_mgmt_01.Helper_Code.Common
{
    public class AuthorizationPrivilegeFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current; 
            if (HttpContext.Current.Session["user"] != null)
            {
                if (HttpContext.Current.Session["user"].ToString() == "Admin")
                {   
                    //filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller" , "Account"} , { "action" , "Login" } });
                    //      filterContext.Result = new RedirectResult("~/");
                
                } else {

                 //  filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller" , "Login" },{ "action" , "NoAccess" } });
                 //  return;
                }
            } else {
               // filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Logout" } });
            }
            base.OnActionExecuting(filterContext);
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
           
            base.OnActionExecuted(filterContext);
        }
    }
}