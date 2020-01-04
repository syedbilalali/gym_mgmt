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
        public String Modules { get; set; }
        public String Action { get; set; }
        public AuthorizationPrivilegeFilter() { 
        }
        public AuthorizationPrivilegeFilter(String Modules , String Action) {
            this.Modules = Modules;
            this.Action = Action;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //To DO ::
            //Get the Value from the Modules and Action Type :
            //Check for current users.
            //Check Action to validate frm the modules List 
            //If is Exist Execute Action and 
            //If is not Exist Redirect Unauthroise Access.
            //  var modules = (string)filterContext.Controller;
            if (Modules != null) {
                if (HttpContext.Current.Session["modules"] != null && HttpContext.Current.Session["user"].ToString() != "Admin")
                {
                    List<ModuleDetails> md =  HttpContext.Current.Session["modules"] as List<ModuleDetails>;
                    ModuleDetails md1 = md.Find(x => x.Module.Equals(Modules));
                    switch (Action) {
                        case "View":
                            if (md1.View != true) {
                                filterContext.Result = new RedirectToRouteResult(
                               new RouteValueDictionary(new { controller = "Home", action = "NoAccess" }));
                            }
                            break;
                        case "Edit":
                            if (md1.Edit != true)
                            {
                                filterContext.Result = new RedirectToRouteResult(
                               new RouteValueDictionary(new { controller = "Home", action = "NoAccess" }));
                            }
                            break;
                        case "Create":
                            if (md1.Create != true)
                            {
                                filterContext.Result = new RedirectToRouteResult(
                               new RouteValueDictionary(new { controller = "Home", action = "NoAccess" }));
                            }
                            break;
                        case "Delete":
                            if (md1.Delete != true)
                            {
                                filterContext.Result = new RedirectToRouteResult(
                               new RouteValueDictionary(new { controller = "Home", action = "NoAccess" }));
                            }
                            break;
                    }

                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}