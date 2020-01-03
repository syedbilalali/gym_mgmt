using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;
using gym_mgmt_01.Models;
namespace gym_mgmt_01.Helper_Code.Common
{
    public class AuthorizationPrivilegeFilter : ActionFilterAttribute , IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            HttpContext ctx = HttpContext.Current; 
            if (HttpContext.Current.Session["user"] != null)
            {
                if (HttpContext.Current.Session["user"].ToString() == "Admin")
                {   
                    //filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller" , "Account"} , { "action" , "Login" } });               
                } else {
                    if (HttpContext.Current.Session["modules"] != null) {
                        List<ModuleDetails> md = HttpContext.Current.Session["modules"] as List<ModuleDetails>;
                        ModuleDetails md1 = md.Find(x => x.Module.Equals("Staff"));
                    }
                    //   filterContext.Result = new RedirectResult("~/Login/NoAccess");
                }
            } else {
               // filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Logout" } });
            }
            
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }
    }
}